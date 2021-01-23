    public partial class IntegrationService : ServiceBase
    {
        private readonly Bootstrapper _bootstrapper;
        private IIntegrationEngine _engine;
        public IntegrationService()
        {
            InitializeComponent();
            _bootstrapper = new Bootstrapper();
        }
        protected override void OnStart(string[] args)
        {
            // Resolve the engine which resolves all dependencies
            _engine = _bootstrapper.GetEngine();
            if (_engine == null)
                Stop();
            else
                _engine.Start();
        }
        protected override void OnStop()
        {
            if (_engine != null)
                _engine.Stop();
        }
    }
