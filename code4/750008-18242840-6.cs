    partial class CalculatorWindowsService : ServiceBase
    {
        public ServiceHost m_host;
        public CalculatorWindowsService()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            // If the host is still open, close it first.
            if (m_host != null)
            {
                m_host.Close();
            }
            // Create a new host
            m_host = new ServiceHost(typeof(CalculatorService), new Uri("net.pipe://localhost"));
            // Note: "MyServiceAddress" is an arbitrary name. You can change it to whatever you want.
            m_host.AddServiceEndpoint(typeof(ICalculatorService), new NetNamedPipeBinding(), "MyServiceAddress");
            m_host.Open();
        }
        protected override void OnStop()
        {
            // Close the host when the service stops
            if (m_host != null)
            {
                m_host.Close();
                m_host = null;
            }
        }
    }
