     foreach (AsteroidClass ac in asteroid)
     {
        if (ac.getAsteroidRectangle().Intersects(missile[i].getMissileRectangle())) // Error here
        {
            missile.Remove(missile[i]); // Or pehaps error here
            ac.asteroidRectangle.X = asteroidPos.Next(Window.ClientBounds.Width - 60);
            ac.asteroidRectangle.Y = asteroidPos.Next(-800, -57);
            break; // this will exist the foreach loop for asteroid.
        }
     }
