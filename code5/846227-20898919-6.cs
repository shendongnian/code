    public class Asteroid
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public float Rotation { get; set; }
        public Rectangle SourceLocation { get; set; }
        public Vector2 SourceOrigin { get; set; }
        public Asteroid()
        {
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(
                Texture,
                Position,
                SourceLocation,
                Color,
                Rotation,
                SourceOrigin,
                1.0f,
                SpriteEffects.None,
                0f);
        }
    }
