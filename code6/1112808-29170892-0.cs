    namespace HttpApiService
    {
    public partial class HttpApiService : ServiceBase
    {
        private HttpSelfHostServer _server;
        //private readonly HttpSelfHostConfiguration _config; // http
        private readonly MyHttpsSelfHostConfiguration _config; // https
        public string ServiceAddress = Settings.Default.URL;
        public HttpApiService()
        {
            InitializeComponent();
            _config = new MyHttpsSelfHostConfiguration(ServiceAddress);
            _config.MapHttpAttributeRoutes();
            _config.Routes.MapHttpRoute("DefaultApi", "{controller}/{id}", new { id = RouteParameter.Optional });
            // added these to solve the upload size problem
            _config.MaxReceivedMessageSize = 5242880; // 5mb
            _config.MaxBufferSize = 5242880; // 5mb
        }
        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry("HttpApiService started.");
            _server = new HttpSelfHostServer(_config);
            _server.OpenAsync();
        }
        protected override void OnStop()
        {
            EventLog.WriteEntry("HttpApiService stopped.");
            _server.CloseAsync().Wait();
            _server.Dispose();
        }
        class MyHttpsSelfHostConfiguration : HttpSelfHostConfiguration
        {
            public MyHttpsSelfHostConfiguration(string baseAddress) : base(baseAddress) { }
            public MyHttpsSelfHostConfiguration(Uri baseAddress) : base(baseAddress) { }
            protected override BindingParameterCollection OnConfigureBinding(HttpBinding httpBinding)
            {
                httpBinding.Security.Mode = HttpBindingSecurityMode.Transport;
                //Console.WriteLine("https is on");
                return base.OnConfigureBinding(httpBinding);
            }
        }
    }
}
