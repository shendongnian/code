    for (int i = 0; i < missile.Count; i++)
    {
        missile[i].setMissileY();
        if (rect_Light.Intersects(missile[i].getMissileRectangle()))
        {
           missile.Remove(missile[i]);
        }
        foreach (AsteroidClass ac in asteroid)
        {
            if (ac.getAsteroidRectangle().Intersects(missile[i].getMissileRectangle())) // Error here
            {
                missile.Remove(missile[i]); // Or pehaps error here
                ac.asteroidRectangle.X = asteroidPos.Next(Window.ClientBounds.Width - 60);
                ac.asteroidRectangle.Y = asteroidPos.Next(-800, -57);
            }
        }
