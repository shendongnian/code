    public class Car : DrawableGameComponent
    {
        private Texture2D texture;
        public Car() : base(GameHolder.Game)
        {
            texture = GameHolder.Game.Content.Load<Texture2D>("mytexture");
        }
    }
