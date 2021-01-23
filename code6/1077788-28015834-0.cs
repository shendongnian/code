    public class Tool : DrawableGameComponent
    {
        public Tool(Game game) : base(game)
        {
            game.Components.Add(this);        
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            // Put draw logic for your tool here
        }
    }
