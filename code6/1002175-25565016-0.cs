    public static class Cards
    {
        private static string[] Suite = new string[4] {"Clubs", "Hearts", "Spades", "Diamonds" };
        private static string[] FaceValue = new string[13] {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
    
    
        public static List<string> CreateDeck()
        {
            var deck = new List<string>();
            for (int s = 0; s < 4; s++ )
            {
                string sut = Suite[s];
    
                for (int fV = 0; fV < 13; fV++)
                {
                    string value = FaceValue[fV];
    
                    deck.Add(sut + value);
                }
            }
            // End of For loop.
            Shuffle(deck);
            return deck;
        }
    
        private static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
