     class Card
     {
         public enum SUIT { SPADES, HEARTS, DIAMONDS, CLUBS };
         public string Value {get; set;}
         public SUIT Suit { get; set; }
         public Card(SUIT suit, string value)
         {
             this.Suit = suit;
             this.Value = value;
         }
     }
     class Deck
     {
         private const Int32 MAXCARDS = 52;
         private Card[] _cards = new Card[MAXCARDS];
         public Deck()
         {
             Card.SUIT[] suits = { Card.SUIT.SPADES, Card.SUIT.HEARTS, Card.SUIT.DIAMONDS, Card.SUIT.CLUBS };
             String[] values = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
             Random rnd = new Random();
             Card[] orderedCards = new Card[suits.Length * values.Length];
             int newIndex = 0;
             // Generate an array with all possible combinations of suits and values
             for (int suitsIndex = 0; suitsIndex < suits.Length; suitsIndex++)
             {
                 for (int valuesIndex = 0; valuesIndex < values.Length; valuesIndex++)
                 {
                     newIndex = values.Length * suitsIndex + valuesIndex; // Think about it :)
                     orderedCards[newIndex] = new Card(suits[suitsIndex], values[valuesIndex]);
                 }
             }
             // Generate an array with random numbers from 0 51 (taken from http://stackoverflow.com/questions/5864921/how-can-i-randomize-numbers-in-an-array)
             int[] randomNumbers = Enumerable.Range(0, this._cards.Length).OrderBy(r => rnd.Next()).ToArray();
             // Now go from 0 to 51 and set a card to a random element of the orderedCards array
             for (int i = 0; i < _cards.Length; i++)
             {
                 this._cards[i] = orderedCards[randomNumbers[i]];
                 Console.WriteLine("Card " + i + " = " + _cards[i].Suit.ToString() + " - " + _cards[i].Value.ToString());
             }
         }
     }
