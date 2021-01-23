    public class ConsoleAppExample
    {
        private readonly Bootstrapper _bootstrapper;
        private IIntegrationEngine _engine;
        public ConsoleAppExample()
        {
            _bootstrapper = new Bootstrapper();
            // Resolve the engine which resolves all dependencies
            _engine = _bootstrapper.GetEngine();
            _engine.Start();
        }
    }
