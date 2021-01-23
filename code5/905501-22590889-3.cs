    public class Player_Main //This class deals with updating all other classes
    {
        public Player_Sprite psprite = new Player_Sprite();
        public Player_Movement pmove = null;
        public Player_Stats pstats = new Player_Stats();
        public Player_Abilities pabilities = new Player_Abilities();
        public Player_Controls pcontrols = new Player_Controls();
        public Player_Main()
        {
             pmove = new Player_Movement(this);
        }
        // ... rest removed for brevity
    }
