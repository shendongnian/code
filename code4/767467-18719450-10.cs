    public class EuchreDeck : Deck
    {
       private static readonly string[] values = new string[] { "9", "10", "J", "Q", "K", "A" };
       private static readonly string[] suits = new string[] { "clubs", "spades", "hearts", "diamonds" };
    
       public EuchreDeck() : base(values, suits)
       {
       
       }
    }
