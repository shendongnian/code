    public abstract class Sprite
    {
        public Vector2 Location { get; set; }
        public Rectangle Bounds
        {
            get
            {
                return new Rectangle((int)Location.X, (int)Location.Y, 
                                     _texture.Width, _texture.Height);
            }
        }
        private Texture2D _texture;
        public Sprite(Texute2D texture)
        {
            _texture = texture;
        }
    }
    public class enemyObjects : Sprite
    {
        // enemy-specific properties go here
        public enemyObjects(Texture2D texture)
            : base(texture)
        {
        }
    }
    public class Bullet : Sprite
    {
        // Bullet-specific properties go here
        public Bullet(Texture2D texture)
            : base(texture)
        {
        }
    }
