    using GameObjects;
    namespace WindowsGameHelp2
    {
        public class Game1 : Microsoft.Xna.Framework.Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
            Shop shop;
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
                shop = new Shop(@"Shops\FruitShop", Content);
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
                shop.Draw(spriteBatch);
                spriteBatch.End();
                base.Draw(gameTime);
            }
        }
    }
