    public struct Card
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }
        public Card(Suit suit, Rank rank)
            : this()
        {
            this.Suit = suit;
            this.Rank = rank;
        }
        // include implementations for GetHashCode, Equals, ==, and !=
    }
