    private int elapsedTime = 0; //Declared at class level
    public override void Update(GameTime gameTime)
    {
        // We add the time spent since the last time Update was run
        elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
        if (elapsedTime > 500) // If last time is more than 500ms ago
        {
            elapsedTime = 0;
            birdbox3.X += 5;
            birdbox3.Y -= 5;
            if (birdbox3.Intersects(Banner1))
            {
                birdbox3.Y += 10;
            }
            else if (birdbox3.Intersects(Banner2))
            {
                birdbox3.Y = -birdbox3.Y;
            }
        }
    }
