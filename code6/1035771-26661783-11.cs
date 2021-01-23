    public class Player
    {
	    . . .
	    public int MaxDarts { get; set; }
		
		public Player(string name, bool isNpc = false)
		{
			. . .
			MaxDarts = 3;
		}
	}
	
	public void GrabDarts()
    {
        dartsInHand = MaxDarts;
    }
	
