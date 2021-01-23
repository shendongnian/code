    enum Suit { Spades, Hearts, Diamonds, Clubs }
    enum Rank { Two, Three, Four, Five, Six, Seven, 
                Eight, Nine, Ten, Jack, Queen, King, Ace }
    enum HandType { Nothing, Pair, TwoPair, ThreeOfAKind, Straight,
         Flush, FullHouse, FourOfAKind, StraightFlush }    
    public struct Card 
    {
       public Suit Suit { get; private set; }
       public Rank Rank { get; private set; }
       public Card(Rank rank, Suit suit)
       {
          Suit = suit;
          Rank = rank;
       }     
    }
    public class Hand 
    {
       public IReadOnlyList<Card> Cards { get; private set };
       public Hand(IEnumerable<Card> cards) 
       { 
          this.Cards = cards.OrderByDescending(c => c.Rank).ToList(); 
       }   
    }
