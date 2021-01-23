    public class Player
    {
        public string Name { get; private set; }
        private int dartsInHand;
        public void GrabDarts()
        {
            dartsInHand = 3;
        }
    }
	
