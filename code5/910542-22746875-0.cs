    public void Update (GameTime gameTime)
    {
        foreach (Asteroids a in asteroidsList)
        {
            a.position = new Vector2(
                MathHelper.Clamp(position.X + speed, -105, 1280),
                MathHelper.Clamp(position.Y + speed, -200, 1024));
        }
    }
