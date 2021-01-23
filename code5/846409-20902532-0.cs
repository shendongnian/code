     void Main()
        {
        	Game g= new Game();
        	g.Initialize();
        	Attack a = new Attack(g);
        	Card c = a.resolve();
        	Console.WriteLine(c.name); //prints "no defense"
        	
        }
        
    //just a guess as to what Card looks like.
        public class Card
        {
        	public string name{get;set;}
        	public Card(string name){this.name=name;}
        }
        
        public class Game 
        {
            bool noDefenseSelected = false;
            Card noDefenseCard;
         
    //this is manually called in this example
            public void Initialize()
            {
               noDefenseCard = new Card("no defense");
               noDefenseSelected=true;
            }   
        
            public Card getCard()
            {
              if (noDefenseSelected)
              {
                 noDefenseSelected = false;
                 return noDefenseCard;
              }
             //all other cases return null in this example.
              return null;
        	}
        
        }
        
          public  class Player
          {
             public Card getDefenseCard(Game game)
             {
               return game.getCard();
             }
          }
        
          public class Attack
          {
             Game game;
             Player defender = new Player();
        
             public Attack(Game game)
             {
                this.game = game;
             }
        
             public Card resolve()
             {
                Card card = defender.getDefenseCard(game);
    //returning card in this case for the example so it can be printed.
        	    return card;
               }
    }
	
	
