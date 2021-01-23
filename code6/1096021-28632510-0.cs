    if (playerBounds.Intersects(groundBounds))
        {
            if (IntersectsPixel(sprite1, sprite2, playerBounds,            
                                                 groundBounds)) //Here
            {
                playerColor = Color.Aqua;
            }
            else
            {
                playerColor = Color.White;
            }
        }
