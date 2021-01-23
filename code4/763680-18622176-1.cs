    public class KeyboardController : IController
    {
        KeyboardState keyboard = Keyboard.GetState();
    
        public void Update()
        {
            if (keyboard.IsKeyDown(Keys.Q))
            {
                // QUIT GAME    
            }
            if (keyboard.IsKeyDown(Keys.F))
            {
                Main.DrawAliveMario = true;           
            }
            if (keyboard.IsKeyDown(Keys.D))
            {
                Main.DrawAliveMario = false;
    
            }
        }
    }
