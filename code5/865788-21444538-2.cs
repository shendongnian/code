    public class ScreenManager
    {
        List<GameScreen> screens;
        bool isinitialized = false;
        public override void Initialize()
        {
            base.Initialize();
            isinitialized = true;
        }
        protected override void LoadContent()
        {
             foreach (GameScreen screen in screens)
                 screen.LoadContent();
        }
    
        public void AddScreen(GameScreen screen)
        {
            screens.Add(screen);
            if (isinitialized) screen.LoadContent();
        }
    
        // also create a removescreen
    
        public void Draw(Gametime gametime)
        {
            foreach (GameScreen screen in screens)
            {
                screen.Draw(gametime);
            }
        }
        // also create a similar method for Updating
    }
