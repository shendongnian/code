    public class ScreenManager
    {
        List<GameScreen> screens;
    
        public void AddScreen(GameScreen screen)
        {
            screens.Add(screen);
        }
    
        // also create a removescreen
    
        public void Draw(Gametime gametime)
        {
            foreach (GameScreen screen in screens)
            {
                screen.Draw(gametime);
            }
        }
        // also create a similar void for Updating
    }
