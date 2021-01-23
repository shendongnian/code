    public override void Draw(SpriteBatch batch)
    {
        batch.Draw(texture, Position, null, Color.White, MathHelper.ToRadians(rotateAngle),
            new Vector2(texture.Width / 2, texture.Height / 2), 1.0f,
            SpriteEffects.None, 0.0f);    
    }
