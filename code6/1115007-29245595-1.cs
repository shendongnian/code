    private static List<Card> GetFreshDeck()
    {
        var freshDeck = new List<Card>();
        for (int i = 0; i < 52; i++)
        {
            // Value is always 1 through 13
            int value = i % 13 + 1;
            // Determine suit based on i
            Suit suit = (i < 13) ? Suit.Hearts 
                : (i < 26) ? Suit.Clubs 
                : (i < 39) ? Suit.Diamonds 
                : Suit.Spades;
            // Add a card to the deck
            freshDeck.Add(new Card(value, suit));
        }
        return freshDeck;
    }
