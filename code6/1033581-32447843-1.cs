        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();
            cards.Add(new Card() { Rank = 0, Suit = 0 });
            int numHands = GenerateAllHands(cards);
            int counter = 0;
            Console.WriteLine(numHands);
            Console.WriteLine(possibleHands.Count);
            foreach (Hand hand in possibleHands)
            {
                counter += 1;
                foreach (Card card in hand.Cards)
                {
                    hand.HandString += GetCardName(card) + " ";
                }
                hand.HandString = hand.HandString.Trim();
            }
            
            Console.ReadLine();
        }
