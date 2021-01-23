    public class Game1 : Microsoft.Xna.Framework.Game
    {
        // ...
    
        protected override void Initialize()
        {
            mapHandler = new Handler.CreateMap();
            tile = mapHandler.createMap();
            textureHandler = new Handler.TextureHandler();
            base.Initialize();
        }
    }
