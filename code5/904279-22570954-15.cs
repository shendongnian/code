    using GameObjects;
    namespace WindowsGameHelp2
    {
        public class Game1 : Microsoft.Xna.Framework.Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
            Sprite apple;
            public Game1()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
            protected override void Initialize()
            {
                base.Initialize();
            }
            protected override void LoadContent()
            {
                spriteBatch = new SpriteBatch(GraphicsDevice);
                //@"Fruits\Apple" is a path to our XML file.
                apple = new Sprite(@"Fruits\Apple", Content);
            }
            protected override void UnloadContent()
            {
            }
            protected override void Update(GameTime gameTime)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();
                base.Update(gameTime);
            }
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.White);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
                apple.Draw(spriteBatch);
                spriteBatch.End();
                base.Draw(gameTime);
            }
        }
    }
