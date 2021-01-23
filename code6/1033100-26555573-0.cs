        public class Gun
        {
            Texture2D gun;
            Vector2 position;
            SoundEffect soundEffect;
            MouseState _previousMouseState, currentMouseState;
            public Gun(ContentManager Content)
            {
                gun = Content.Load<Texture2D>("Gun");
                soundEffect = Content.Load<SoundEffect>("gunshot");
                position = new Vector2(10, 10);
            } 
            public void Update(GameTime gameTime)
            {
                // Keep track of the previous state to only play the effect on new clicks and not when the button is held down
                _previousMouseState = _currentMouseState;
                _currentMouseState = Mouse.GetState();
                if(_currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton != ButtonState.Pressed)
                   soundEffect.Play();
            }
        }
