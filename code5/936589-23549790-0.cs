    Position = new Vector2(Texture.Width / 2 * Scale, Texture.Width / 2 * Scale);
    return new Rectangle(
                (int)(Position.X),
                (int)(Position.Y),
                (int)(Texture.Width * Scale),
                (int)(Texture.Height * Scale)
                );
