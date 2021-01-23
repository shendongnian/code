        public class CardDeck : IEnumerable<Card>
        {
            private List<Card> _cards;
            public Card this[int index] { get { return _cards[index]; } private set; }
            
            public CardDeck()
            {
                string[] suits = new string[4] {"Clubs", "Hearts", "Spades", "Diamonds" };
                int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
                _cards = new List<Card>();
                // Populate deck
                for (int i = 0; i < values.Length; i++)
                {
                    int value = values[i];
                    for (int x = 0; i < suits.Length; x++)
                    {
                        _cards.Add(new Card(value, suits[x]));
                    }
                }
            }
            public void Shuffle()
            {
                // shuffle based on http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
                Random rng = new Random();
                int n = _cards.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    var value = _cards[k];
                    _cards[k] = _cards[n];
                    _cards[n] = value;
                }  
            }
            public IEnumerator<Card> GetEnumerator()
            {
                for (int index = 0; index < _cards.Count; index++)
                {
                    yield return _cards[index];
                }
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        
