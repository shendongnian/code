    void Update(GameTime gameTime)
    {
        Position.X += (float)Math.Cos(Angle) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        Position.Y += (float)Math.Sin(Angle) * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
    }
