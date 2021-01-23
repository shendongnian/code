    public class Player
    {
       public void Initialize()
       {
           // An example of initialization logic
           Hand = new Card[4];
           for (int i = 0; i < Hand.Length; i++)
               Hand[i] = new Card();
       }
    
       public Card[] Hand { get; set; } 
    }
    public class Card
    {
    }
