    public void Update (GameTime gameTime)
    {
        foreach (Asteroids a in asteroidsList)
        {
            a.position = new Vector2(
                MathHelper.Clamp(a.position.X + speed, -105, 1280),
                MathHelper.Clamp(a.position.Y + speed, -200, 1024));
        }
    }
