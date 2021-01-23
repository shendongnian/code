    public KeyboardState PreviousKeyboardState = Keyboard.GetState();
    public Boolean FullscreenMode = false;
    public Vector2 WindowedResolution = new Vector2(800,600);
    public Vector2 FullscreenResolution = new Vector2(1280, 720);
    public void UpdateDisplayMode(bool fullscreen, Vector2 resolution)
    {
        graphics.PreferredBackBufferWidth = (int)resolution.X;
        graphics.PreferredBackBufferHeight = (int)resolution.Y;
        graphics.IsFullScreen = fullscreen;
        graphics.ApplyChanges();
    }
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    
        IsMouseVisible = true;
        UpdateDisplayMode(FullscreenMode);
    }
    
    protected override void Update(GameTime gameTime)
    {
        // Allows the game to exit
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();
    
        var keyboardState = Keyboard.GetState();
    
    
        if (keyboardState.IsKeyDown(Keys.F) && PreviousKeyboardState.IsKeyUp(Keys.F))
        {
            if (FullscreenMode)
                UpdateDisplayMode(false, WindowedResolution);
            else
                UpdateDisplayMode(true, FullscreenResolution);
        }
    
        PreviousKeyboardState = keyboardState;
        base.Update(gameTime);
    }
