    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        // ...
       
        // Class initialization
        private Map map = new Map() { Width = 10, Height = 10, TileWidth = 16, TileHeight = 16 };
        // Variable declaration
        List<Vector2> blockPos = new List<Vector2>();
        Texture2D dirtTex;
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            dirtTex = Content.Load<Texture2D>("dirt");
            blockPos = map.generateMap();
        }
        // ...
    }
