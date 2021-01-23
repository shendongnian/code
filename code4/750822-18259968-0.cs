    //define your private variables
    private MouseState prevMouseState = null;
    private MouseState currMouseState = Game.MouseState;
    public void Update(GameTime gt)
    {
        prevMouseState = currMouseState;
        currMouseState = Game.MouseState;
        
        //calculate how much the mouse has moved since the last update
        var dX = currMouseState.X - prevMouseState.X;
        var dY = currMouseState.Y - prevMouseState.Y;
        //do your rotating depending on the values of dX and dY
    }
