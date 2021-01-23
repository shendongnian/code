    public class Player
    {
        . . .
		
		public bool IsNpc { get; private set; }
		
		public Player(string name, bool isNpc = false)
        {
            . . .
			
            IsNPC = isNpc;
        }
    }
