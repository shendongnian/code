    public class Player_Main 
    {
        public Player_Sprite psprite;
        public Player_Main()
        {
            psprite = new Player_Sprite(this);
        }
    }
    public class Player_Sprite 
    {
        public Player_Main _pmain;
        public Player_Sprite(Player_Main pmain)
        {
            _pmain = pmain;
        }
    }
