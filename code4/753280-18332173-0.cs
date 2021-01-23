    public void Update(Character c, GameTime gameTime)
    {
        MouseState mouse = Mouse.GetState();
        distance.X = c.Position.X - position.X;
        distance.Y = c.Position.Y - position.Y;
    ...
