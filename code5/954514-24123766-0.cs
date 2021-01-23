    int clipIndex = 0;
    ...
    
    FireTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
    if (kbState.IsKeyDown(Keys.Space) && clipIndex < bullets.Count() FireTimer > FireRate)
    {
        if (bullets[clipIndex].IsAlive == false)
        {
            bullets[i].IsAlive = true;
            bullets[i].position = position;
            FireTimer = 0f;
        }
        clipIndex++;
     }
