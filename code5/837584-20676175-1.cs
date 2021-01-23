    public KeyboardState PreviousKeyboardState = Keyboard.GetState();
    
    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    
        IsMouseVisible = true;
        graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
        graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
    }
    
    protected override void Update(GameTime gameTime)
    {
        // Allows the game to exit
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();
    
        var keyboardState = Keyboard.GetState();
    
    
        if (keyboardState.IsKeyDown(Keys.F) && PreviousKeyboardState.IsKeyUp(Keys.F))
        {
            //This should change resolution and apply changes:
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            graphics.ToggleFullScreen();
        }
    
        PreviousKeyboardState = keyboardState;
        base.Update(gameTime);
    }
