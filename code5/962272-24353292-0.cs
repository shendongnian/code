    public class Player : Microsoft.Xna.Framework.GameComponent
    {
        public Vector2 Pos { get; set; }
        public Player(Game game) : base(game)
        {
            this.Pos = new Vector2(50, 50);
        }
        
        public override void Initialize() { base.Initialize(); }
        public override void Update(GameTime gameTime)
        {
            var ms = Mouse.GetState();
            Pos.X = ms.X;
            Pos.Y = ms.Y;
            base.Update(gameTime);
        }
    }
