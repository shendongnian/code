    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // ...
        protected override void Update(GameTime gameTime)
        {
            // ...
            // Check if Enter was pressed - if so, generate a new map
            if (CheckInput(Keys.Enter, 1))
            {
                blocks = newMap(map, blocks, console);
            }
            // ...
        }
        // Method: Checks if a key is/was pressed
        public bool CheckInput(Keys key, int checkType)
        { 
            KeyboardState newState = Keyboard.GetState();   // Get current keyboard state
            bool retType = false;                           // Return type
            var debug_new = newState.IsKeyDown(key);
            var debug_old = oldState.IsKeyDown(key);
            
            if (checkType == 0)         // Check Type: Is key currently down?
            {
                retType = newState.IsKeyDown(key);
            }
            // Should happen only once, if key wasn't pressed before
            else if (checkType == 1 && newState.IsKeyDown(key))    
            {
                // Key pressed, wasn't pressed last update  -> true. 
                // Key pressed, but was pressed last update -> false.
                retType = !oldState.IsKeydown(key); 
            }
            oldState = newState;            // Save keyboard state
            return retType;                 // Return result
        }
        // ...
    }
