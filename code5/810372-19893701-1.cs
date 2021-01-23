    namespace GameName2
    {
        public class Game1 : Game
        {
            private Texture2D _texture2D;
            private GraphicsDeviceManager graphics;
            private SpriteBatch spriteBatch;
    
            protected override void LoadContent()
            {
                // Create a new SpriteBatch, which can be used to draw textures.
                spriteBatch = new SpriteBatch(GraphicsDevice);
    
                // TODO: use this.Content to load your game content here
                _texture2D = Content.Load<Texture2D>("assets/snap0009");
            }
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
    
                // TODO: Add your drawing code here
                spriteBatch.Begin();
                spriteBatch.Draw(_texture2D, Vector2.Zero, Color.White);
                spriteBatch.End();
                base.Draw(gameTime);
            }
        }
    }
