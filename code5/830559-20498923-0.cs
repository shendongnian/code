    public void DrawFrame(SpriteBatch batch, int frame, Vector2 screenPos)
    {
        Position = screenPos;
        int FrameWidth = myTexture.Width / framecount;
        Rectangle sourcerect = new Rectangle(FrameWidth * frame, 0, FrameWidth, myTexture.Height);
        batch.Draw(myTexture, Position, sourcerect, Color.White, Rotation, Origin, Scale, SpriteEffects.None, Depth);
    }
