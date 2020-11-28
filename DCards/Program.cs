using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCards
{
    class Program
    {
        class Card
        {
            public string Value { get; set; }

            public string Suit { get; set; }

            public Card(string value, string suit)
            {
                Value = value;
                Suit = suit;
            }

            public override string ToString()
            {
                return string.Format("{0} of suit {1}", Value, Suit);
            }
        }

        class Deck : IEnumerable<Card>
        {
            private IEnumerable<Card> cards;
            private readonly string[] suits = new string[] { "clubs(♣)", "diamonds(♦)", "hearts(♥)", "spades(♠)"};
            public Deck()
            {
                cards = new List<Card>();
                cards = this.BuildDeck();
            }

            public void Shuffle()
            {
                Random rand = new Random();
                var cardsArray = cards.ToArray();
                Card ckeep;
                for (int i = cards.Count() - 1; i > 0 ; i--)
                {
                    var r = rand.Next(0, i);
                    ckeep = cardsArray[i];
                    cardsArray[i] = cardsArray[r];
                    cardsArray[r] = ckeep;
                }
                cards = cardsArray.ToList();
            }

            public void Show() {
                foreach (var item in cards)
                {
                    Console.WriteLine(item.ToString());
                }
            } 
            private IEnumerable<Card> BuildDeck()
            {
                foreach (var suit in suits)
                {
                    for (int i = 1; i < 14; i++)
                    {
                        if (i == 1) { yield return new Card("A", suit); }
                        else if (i == 11) { yield return new Card("J", suit); }
                        else if (i == 12) { yield return new Card("Q", suit); }
                        else if (i == 13) { yield return new Card("K", suit); }
                        else { yield return new Card(i.ToString(), suit); }
                    }
                }
            }

            public IEnumerator<Card> GetEnumerator()
            {
                return (IEnumerator<Card>)this.cards;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.cards.GetEnumerator();
            }
        }
        static void Main(string[] args)
        {

            Deck mainDeck = new Deck();
            Console.WriteLine("Before shuffle");
            mainDeck.Show();

            mainDeck.Shuffle();
            Console.WriteLine("After shuffle");
            mainDeck.Show();
            Console.ReadKey();
        }
    }
}
