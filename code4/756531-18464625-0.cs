    public class Context
    {
        private GameState state;
        public void Update()
        {
             state.Update();
        }
        public void ChangeState(GameState nextState)
        {
             state = nextState;
        }
    }
    public abstract class GameState
    {
        protected Context context;
        public virtual void Update()
        {
            // some basic implementation if you want.
        }
    }
    public class GameLoadingState : GameState
    {
        public override void Update()
        {
            // Handle key presses.
            context.ChaneState(new MainMenuState(context));
        }
    }
    public class MainMenuState : GameState
    {
        public override void Update()
        {
            // Handle key presses in some other way.
            // Change state if needed.
        }
    }
