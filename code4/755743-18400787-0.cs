    private void CalculateAngleAndDirection(Vector2 from, Vector2 to, out Vector2 direction, out float angle)
    {
        direction = to - from; //get the direction vector
        direction.Normalize(); //make it a unit vector
        angle = (float)Math.Atan2(-direction.X, direction.Y);
    }
    protected override void Update(GameTime gameTime)
    {
        //...
        MouseState mouse = Mouse.GetState();
        mousePos.X = mouse.X;
        mousePos.Y = mouse.Y;
        CalculateAngleAndDirection(position, mousePos, out direction, out angle); 
        position += direction * 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
        base.Update(gameTime);
    }
