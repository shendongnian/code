    public class WebServiceHost : IDisposable
    {
        public WebServiceHost()
        {
            _tcpBaseAddress = "net.tcp://localhost:" + Globals.ClientTcpPort + "/V1";
            _httpBaseAddress = "http://localhost:" + Globals.ClientHttpPort + "/V1";
            List<Uri> addresses = new List<Uri>() { new Uri(_httpBaseAddress), new Uri(_tcpBaseAddress)};
            _host = new System.ServiceModel.Web.WebServiceHost(typeof(Service), addresses.ToArray());
            IsOpen = false;
        }
        readonly System.ServiceModel.Web.WebServiceHost _host;
        readonly string _httpBaseAddress;
        readonly string _tcpBaseAddress;
        public static bool IsOpen { get; set; }
        public void OpenHost()
        {
            try
            {
                //WebHttpBinding
                WebHttpBinding webBinding = new WebHttpBinding();
                webBinding.MaxBufferPoolSize = int.MaxValue;
                webBinding.MaxReceivedMessageSize = int.MaxValue;
                webBinding.Security.Mode = WebHttpSecurityMode.None;
                webBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                //NetTcpBinding
                NetTcpBinding tcpBinding = new NetTcpBinding();
                tcpBinding.MaxBufferPoolSize = int.MaxValue;
                tcpBinding.MaxReceivedMessageSize = int.MaxValue;
                tcpBinding.Security.Mode = SecurityMode.None;
                tcpBinding.Security.Message.ClientCredentialType = MessageCredentialType.None;
                //ServiceBehavior
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpsGetEnabled = false;
                smb.HttpGetEnabled = true;
                _host.Description.Behaviors.Add(smb);
                ServiceDebugBehavior sdb = _host.Description.Behaviors.Find<ServiceDebugBehavior>();
                sdb.HttpHelpPageEnabled = Globals.IsDebugMode;
                sdb.HttpsHelpPageEnabled = Globals.IsDebugMode;
                sdb.IncludeExceptionDetailInFaults = Globals.IsDebugMode;
                UseRequestHeadersForMetadataAddressBehavior urhfmab = new UseRequestHeadersForMetadataAddressBehavior();
                _host.Description.Behaviors.Add(urhfmab);
                //MEX endpoint
                _host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                if (Globals.UseClientTcpHost && Globals.UseClientHttpHost)
                {
                    _host.AddServiceEndpoint(typeof(IService), tcpBinding, _tcpBaseAddress);
                    _host.AddServiceEndpoint(typeof(IService), webBinding, _httpBaseAddress);
                    _host.Description.Endpoints[2].Contract = CopyContract(_host.Description.Endpoints[1].Contract);
                } 
                else if (Globals.UseClientTcpHost)
                {
                    _host.AddServiceEndpoint(typeof(IService), tcpBinding, _tcpBaseAddress);
                }
                else if (Globals.UseClientHttpHost)
                {
                    _host.AddServiceEndpoint(typeof(IService), webBinding, _httpBaseAddress);
                    _host.Description.Endpoints[1].Contract = CopyContract(_host.Description.Endpoints[1].Contract);
                }
                _host.Open();
                IsOpen = true;
