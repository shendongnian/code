    public class Car : DrawableGameComponent
    {
        private List<Texture2D> states;
        private Texture2D currentState;
        private SpriteBatch spriteBatch;
        public Car(Game game, SpriteBatch sb) : base(GameHolder.Game)
        {
            states.Add(game.Content.Load<Texture2D>("state1"));
            states.Add(game.Content.Load<Texture2D>("state2"));
            states.Add(game.Content.Load<Texture2D>("state3"));
            currentState = states[0];
            spriteBatch = sb;
        }
        public override void Update(GameTime gameTime)
        {
            if (someCondition)
            {
                currentState = states[0];
            }
            else if (someOtherCondition)
            {
                currentState = states[1];
            }
            else if (moreConditions)
            {
                currentState = states[2];
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Draw(currentState, new Vector2(0,0), Color.White);
            base.Draw(gameTime);
        }
    }
