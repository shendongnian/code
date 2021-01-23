    public class Game1 : Microsoft.Xna.Framework.Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
            Texture2D star;
            Random rand;
            star STAR;
    
        
    
    public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
    
        
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            
            base.Initialize();
        }
    
        
        protected override void LoadContent()
        {
            rand = new Random();
            spriteBatch = new SpriteBatch(GraphicsDevice);            
            star = Content.Load<Texture2D>("Bitmap1");
            STAR = new star(rand, star);
     
        }
    
        
        protected override void UnloadContent()
        {
            
        }
    
        
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
    //calls on_hit every update call after 4 seconds. just for demo purpose. 
            if (gameTime.TotalGameTime > TimeSpan.FromSeconds(4))
                STAR.on_hit();
            STAR.update(gameTime);
            base.Update(gameTime);
        }
    
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
    
            spriteBatch.Begin();
            STAR.draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
