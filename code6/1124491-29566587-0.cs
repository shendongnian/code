    Player player;
    KeyboardState oldState; // player and oldState belongs to the whole game
    protected override void Initialize() {
        player = new Player(this, Content, spriteBatch);
        base.Initialize();
    }
    protected override void Update(GameTime gameTime) {
        KeyboardState newState = Keyboard.GetState(); // newState belongs to this exact update only
        
        if (newState.IsKeyDown(Keys.Right) && oldState.IsKeyUp(Keys.Right)) {
            player.playerMove(newState, oldState); // not sure why you wish to pass these arguments?
        }
        oldState = newState;
    }
