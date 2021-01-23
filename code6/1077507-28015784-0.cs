    public class Customer
    {
        public int CustomerId { get; private set; }
        public virtual Card Card { get; set; }
    }
    public abstract class Card
    {
        public int CustomerId { get; private set; }
    }
	public class Visa : Card { }
	public class Amex : Card { }
