    if (playerBounds.Intersects(groundBounds))
        {
            if (IntersectsPixel(character, ground, playerBounds,            
                                                 groundBounds))
            {
                playerColor = Color.Aqua;
            }
            else
            {
                playerColor = Color.White;
            }
        }
