    if (ks.IsKeyDown(Keys.A) && directionPointer == 1 && oldKs.IsKeyUp(Keys.A))
    {
        isAnimationRunning = true;
    }
    if(isAnimationRunning)
    {
        attackTime += gameTime.ElapsedGameTime.Milliseconds;
        if (attackTime > 1 && attackTime < 100)
        {
            currentSprite = new Rectangle(3, 46, 32, 16);
        }
        else if (attackTime < 200 && attackTime > 100)
        {
            currentSprite = new Rectangle(33, 61, 32, 32);
        }
        else if (attackTime > 200 && attackTime < 300)
        {
            currentSprite = new Rectangle(61, 65, 16, 32);
        }
        else if (attackTime > 300)
        {
            attackTime = 0;
            isAnimationRunning = false;
        }
    }
