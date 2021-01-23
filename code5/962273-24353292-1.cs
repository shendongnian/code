    public class RPG : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D PlayerTex;
        
        Player player;
        public RPG()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            player = new Player(this);
            Components.Add(player);
        }
        protected override void Initialize() { base.Initialize(); }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            PlayerTex = Content.Load<Texture2D>("testChar");
        }
        protected override void UnloadContent() { }
        protected override void Update(GameTime gameTime)
        {
            if 
            (
                GamePad.GetState(PlayerIndex.One)
                .Buttons.Back == ButtonState.Pressed
            )
                this.Exit();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(PlayerTex, player.Pos, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
