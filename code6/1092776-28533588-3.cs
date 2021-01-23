    public class InputState : GameComponent
    {
        private KeyboardState currentKeyboardState;
        private KeyboardState lastKeyboardState;
        private MouseState lastMouseState;
        private MouseState currentMouseState;
        public InputState(Game game) : base(game)
        {
            game.Components.Add(this);
            currentKeyboardState = new KeyboardState();
            lastKeyboardState = new KeyboardState();
            currentMouseState = new MouseState();
            lastMouseState = new MouseState();
        }
        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            lastMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            base.Update(gameTime);
        }
        public bool IsNewLeftClick()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed &&
                lastMouseState.LeftButton == ButtonState.Released;
        }
        public bool IsNewRightClick()
        {
            return currentMouseState.RightButton == ButtonState.Pressed &&
                lastMouseState.RightButton == ButtonState.Released;
        }
        public Point GetMousePosition()
        {
            return new Point(currentMouseState.X, currentMouseState.Y);    
        }
        public bool IsNewKeyPress(params Keys[] keys)
        {
            return keys.Any(k => (currentKeyboardState.IsKeyDown(k) &&
                        lastKeyboardState.IsKeyUp(k)));
        }
        public bool IsCurrentlyPressed(params Keys[] keys)
        {
            return keys.Any(k => currentKeyboardState.IsKeyDown(k));
        }
    }
