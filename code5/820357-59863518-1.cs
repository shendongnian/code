	public abstract class AMGC<StartScreen,LoadScreen> : Game where StartScreen:IScreen,new() where LoadScreen:IScreen,new()
	{
		public GraphicsDeviceManager graphics;
		internal bool isLoading;
        internal IScreen CurrentScreen,LoadingScreen;
	    public AMGC()
        {
            graphics = new GraphicsDeviceManager(this);
			isLoading = false;
		}
        protected override void Initialize()
        {
            CurrentScreen = new StartScreen();
            LoadingScreen = new LoadScreen();
            base.Initialize();
        }
        protected override void LoadContent()
		{
			CurrentScreen.LoadContent();
			LoadingScreen.LoadContent();
			base.LoadContent();
		}
		protected override void Draw(GameTime gt)
		{
			if (isLoading) LoadingScreen.Draw(gt);
			else CurrentScreen.Draw(gt);
			base.Draw(gt);
		}
		protected override void Update(GameTime gameTime)
		{
			if (isLoading) LoadingScreen.Update(gameTime);
			else CurrentScreen.Update(gameTime);
			base.Update(gameTime);
		}
		public void ScreenLoad<T>() where T : IScreen, new()
		{
			isLoading = true;
			Task.Run(() =>
				{
					var screen = new T();
					screen.LoadContent();
					CurrentScreen = screen;
					isLoading = false;
				}
			);
		}
	}
