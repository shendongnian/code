    public class ScreenFactory
    {
        private readonly ILifetimeScope _parent;
        public ScreenFactory(ILifetimeScope parent) { _parent = parent; }
        public TScreen CreateScreen<TScreen>() where TScreen : Screen
        {
            var screenScope = _parent.BeginLifetimeScope("Screen");
            var screen = screenScope.Resolve<TScreen>();
            screen.Closed += () => screenScope.Dispose();
            return screen;
        }
    }
