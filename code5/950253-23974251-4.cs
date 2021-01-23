    public class Car : DrawableGameComponent
    {
        private Texture2D texture;
        public Car(Game game) : base(game)
        {
            texture = game.Content.Load<Texture2D>("mytexture");
        }
    }
