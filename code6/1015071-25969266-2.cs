    public enum Suite
    {
        Clubs, 
        Hearts, 
        Spades, 
        Diamonds
    }
    public enum Value
    {
        Ace, 
        Two, 
        Three, 
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack, 
        Queen, 
        King
    }
    public class Card
    {
        public Card(Suite suite, Value value, decimal score)
        {
            Suite = suite;
            Value = value;
            Score = score;
        }
        public Suite Suite { get; private set; }
        public Value Value { get; private set; }
        public decimal Score { get; private set; }
    }
