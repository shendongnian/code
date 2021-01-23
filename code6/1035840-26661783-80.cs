    public class Player
    {
	    . . .		
		private readonly Random rnd;
		
		public Player(string name, bool isNpc = false)
        {
		    . . .
		    rnd = new Random();
		}
    }
	
