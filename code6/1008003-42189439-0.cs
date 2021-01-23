    public class ServiceAccessor
    {
        static string serviceUrl = "http://172.16.12.17:7698/HisDashboardService/";
        public static readonly EndpointAddress ProfilerServiceEndPoint = new EndpointAddress(serviceUrl + "ProfilerService.svc");
        private ProfilerServiceClient _profilerServiceClient;
        private static ServiceAccessor _instanceServiceAccessor;
        public static ServiceAccessor Instance
        {
            get { return _instanceServiceAccessor ?? (_instanceServiceAccessor = new ServiceAccessor()); }
        }
        ServiceAccessor()
        {
            InitializeServiceClient();
        }
        private void InitializeServiceClient()
        {
            BasicHttpBinding binding = CreateBasicHttp();
            #region ProfilerService
            _profilerServiceClient = new ProfilerServiceClient(binding, ProfilerServiceEndPoint);
            #endregion ProfilerService
        }
        private static BasicHttpBinding CreateBasicHttp()
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "basicHttpBinding",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };
            TimeSpan timeout = new TimeSpan(1, 0, 0);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;
            return binding;
        }
    }
