    namespace ciao
    {
        public class Game1 : Microsoft.Xna.Framework.Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
            public Item[] gameObjects = new Item[5];
            MyClass myClass = new MyClass(gameObjects);
        }
    }
