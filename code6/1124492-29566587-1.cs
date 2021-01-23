    Player player;
    KeyboardState oldState; // player and oldState belongs to the whole game
    protected override void Initialize() {
        // remember that spriteBatch is still null here
        player = new Player(this, Content, spriteBatch);
        // the line below initializes the spriteBatch
        // check the comments to see why this exact code won't work
        base.Initialize();
    }
    protected override void Update(GameTime gameTime) {
        KeyboardState newState = Keyboard.GetState(); // newState belongs to this exact update only
        
        if (newState.IsKeyDown(Keys.Right) && oldState.IsKeyUp(Keys.Right)) {
            player.playerMove(newState, oldState); // not sure why you wish to pass these arguments?
        }
        oldState = newState;
    }
    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        renderMap createMap = new renderMap(this, this.Content, this.spriteBatch);
        createMap.RenderMap();
        // the player here is the same player in the Update method
        player.drawPlayer();
        base.Draw(gameTime);
    }
