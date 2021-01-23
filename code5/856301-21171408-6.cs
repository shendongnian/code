    public override void Update(GameTime gameTime)
    {
        initialPos.Y += 3.5f;
        rectangle.Y +=  3.5f;
        if (initialPos.X < 300){
            initialPos.X += 0.41f;
            rectangle.X += 0.41f;
    }
        if (initialPos.X > 300)
            initialPos.X -= 0.41f;
            rectangle.X -= 0.41f;
    }
