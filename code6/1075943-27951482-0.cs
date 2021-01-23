    public void AnimateLoop(GameTime gameTime, int loopFirstFrame, int loopLastFrame)
    {
        timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
        if (timeSinceLastFrame > milisecondsPerFrame)
        {
            timeSinceLastFrame -= milisecondsPerFrame;
            currentFrame++;
        }
        if (currentFrame > loopLastFrame || currentFrame < loopFirstFrame)
            currentFrame = loopFirstFrame;
    }
