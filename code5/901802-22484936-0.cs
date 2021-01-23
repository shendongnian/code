    public void Update(GameTime gameTime)
    {
        if (CollisionDetected())
        {
            Xvelocity = -Xvelocity;
            Yvelocity = -Yvelocity;
        }
        position.X += Xvelocity;
        position.Y += Yvelocity;     
        this.rectangle = new Rectangle(position.X, position.Y, rectangle.Width, rectangle.Height);     
    }
