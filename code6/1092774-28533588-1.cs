    //Define this at class level
    private MouseState lastMouseState = new MouseState();
    protected override void Update(GameTime gameTime)
    {
        // your other stuff
        MouseState currentState = Mouse.GetState(); //Get the state
        if (currentState.LeftButton == ButtonState.Pressed &&
            lastMouseState.LeftButton == ButtonState.Released) //Will be true only if the user is currently clicking, but wasn't on the previous call.
        {
            display = !display; //Toggle the state between true and false.
        }
        lastMouseState = currentState;
    }
