    public static class BlackJack
    {
        public static IEnumerable<Card> CreateNewDeck()
        {
            var suits = Enum.GetValues(typeof(Suite)).Cast<Suite>();
            var values = Enum.GetValues(typeof(Value)).Cast<Value>();
            // Create a new deck that contains all cards as often as needed.
            var simpleDeck = suits.SelecMany(suit => values.Select(value => new Card(suit, value)));
            // E.g. in one BlackJack deck you'll find all cards four times (IMHO).
            var deck = Enumerable.Repeat(simpleDeck, 4).SelectMany(x => x);
                                 .ToList();
            deck.Shuffle();
            return deck;
        }
        public static decimal ComputeScore(IEnumerable<Card> playerCards)
        {
            // Iterate through all cards the player is currently holding
            // and tell the current player score.
            throw new NotImplementException();
        }
    }
