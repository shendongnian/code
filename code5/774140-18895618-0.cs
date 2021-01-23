    using RestfulService;
    public partial class Service1 : ServiceBase
    {
        
        public Service1()
        {
            InitializeComponent();
        }
        
        WebServiceHost sHost;
        
        protected override void OnStart(string[] args)
        {
            try
            {
                sHost = new WebServiceHost(typeof(RestfulService.Service1));
                sHost.Open();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ex.Message);
            }
        }
        protected override void OnStop()
        {
            sHost.Close();
        }
    }    
