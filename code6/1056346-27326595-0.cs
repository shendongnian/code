    public Deck()
    {
        Card.SUIT[] suits = { Card.SUIT.SPADES, Card.SUIT.HEARTS, Card.SUIT.DIAMONDS, Card.SUIT.CLUBS };
        String[] values = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        int newIndex = 0;
        // Generate an array with all possible combinations of suits and values
        for (int suitsIndex = 0; suitsIndex < suits.Length; suitsIndex++)
        {
            for (int valuesIndex = 0; valuesIndex < values.Length; valuesIndex++)
            {
                newIndex = values.Length * suitsIndex + valuesIndex; // Think about it :)
                _cards[ newIndex ] = new Card(suits[suitsIndex], values[valuesIndex]) );
            }
        }
    }
