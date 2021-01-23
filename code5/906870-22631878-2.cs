      // First (as you've mentioned in the comment) you need a Card class
      public class Card {
        public String Suit { get; private set; }
        public String Value { get; private set; }
        public String Face { get; private set; }
      }
    
      // An so you have a dictionary solution
      Dictionary<string, List<Card>> cards = new Dictionary<string, List<Card>>() {
        {"Player", new List<Card>()}, 
        {"Dealer", new List<Card>()}
      };
