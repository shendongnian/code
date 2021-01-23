    public RectangleF rectangle;
    public Enemy(Texture2D texture, Vector2 initialPos, Vector2 origin, SpriteBatch spriteBatch) : base(texture, initialPos, origin, spriteBatch)
    {
        this.rectangle = new RectangleF(initialPos.X, initialPos.Y, 48, 48);
    }
    public override void Update(GameTime gameTime)
    {
        rectangle.Y += 3.5f;
        if (rectangle.X < 300)
            rectangle.X += 0.41f;
        if (rectangle.X > 300)
            rectangle.X -= 0.41f;
    }
