    public class Sprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        
        public Sprite(Texture2D texture, Vector2 initialPosition)
        {
             Texture = texture;
             Position = initialPosition;
        }
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
