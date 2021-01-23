    public class Sprite
    {
        public Sprite(Texture2D texture, Vector2 position, Rectangle boundry)
            : this(texture, position, boundry, 1, 1, 1)
        {
        }
        public Sprite(Texture2D texture, Vector2 position, Rectangle boundry,
                      int rows, int cols, double framesPerSecond)
        {
            Initialize(texture, position, boundry, rows, cols, framesPerSecond);
        }
        public Sprite(ContentManager content, Rectangle boundry)
        {
             //TODO: Load up texture with content and get position
             Initialize(texture, position, boundry);
        }
        private void Initialize(Texture2D texture, Vector2 position, Rectangle boundry,
                                int rows, int cols, double framesPerSecond)
        {
            //TODO: Set a bunch of properties here        
        }
        private void Initialize(Texture2D texture, Vector2 position, Rectangle boundry)
        {
            Initialize(texture, position, boundry, 2, 2, 14);
        }
    }
