    public class Game1 : Game
	{
		// Graphic variables used for the game to work
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		BmFont fontTime;
		public Game1 ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";	            
			graphics.IsFullScreen = true;		
		}
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch (GraphicsDevice);
			fontTime = new BmFont ("time.fnt", "time_0.png", this.Content);
		}
			
		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);
			spriteBatch.Begin();
				fontTime.draw (DateTime.Now.ToString("HH mm"), new Vector2 (100, 50)), spriteBatch);
			spriteBatch.End();
			base.Draw (gameTime);
		}
			
	}
