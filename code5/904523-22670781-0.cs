    public class TitleScreen
    {
        Game1 game1;
    
        public void Initialize(Game game1) //Or (Game1 game1) both work since Game1 is a child from Game.
        {
            this.game1 = new Game1();
        }
    }
