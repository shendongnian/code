	public class InputHolder
	{
		public string Input { get; set; }
	}
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		InputHolder inputHolder = new InputHolder();
		public Game1()
			: base()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			inputHolder.Input = "Enter your keys: ";
		}
		protected override void Initialize()
		{
			base.Initialize();
			InputManager.inputHolderToUpdate = inputHolder;
		}
		
		// etc
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			base.Draw(gameTime);
			Console.WriteLine(inputHolder.Input);
		}
	} 
	static class InputManager
	{
		public static InputHolder inputHolderToUpdate;
		public static void update(KeyboardState kbState)
		{
			if (inputHolderToUpdate != null)
			{
				foreach (Keys k in kbState.GetPressedKeys())
				{
					inputHolderToUpdate.Input = inputHolderToUpdate.Input + k.ToString();
				}
			}
		}
	}
