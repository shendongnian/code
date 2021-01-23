    void Update()
    {
        var center = this.Window.ClientBounds;
        MouseState newState = Mouse.GetState();
        double angle = Math.Atan2(newState.Y - center.Y, newState.X - center.X);
        // Change camera angle. Needs to be tuned to your wants most likely.
        Mouse.SetPosition((int)center.X, (int)center.Y);
    }
