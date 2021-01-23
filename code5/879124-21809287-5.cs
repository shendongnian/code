    public class Class1: DrawableGameComponent
    {
        public Class1(Game game)
            : base(game)
        {
        }
        protected override void LoadContent()
        {
            var tex = this.Game.Content.Load<Texture2D>("test");
        }
    }
