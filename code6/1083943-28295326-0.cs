      private void InitailizeService()
      {
         try
         {
            var serviceAddress = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ServiceAddress");
            var serviceNamespace = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ServiceNamespace");
            var protocol = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.Protocol");
            string issuerName = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ServiceIssuerName");
            string issuerSecret = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ServiceIssuerSecret");
            Uri uri = ServiceBusEnvironment.CreateServiceUri(protocol, serviceAddress, serviceNamespace);
            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Http;
            _host = new ServiceHost(typeof(WorkerRoleService));
            TokenProvider tp = null;
            if (!String.IsNullOrEmpty(issuerName))
            {
               tp = TokenProvider.CreateSharedSecretTokenProvider(issuerName, issuerSecret);
            }
            var sharedSecretServiceBusCredential = new TransportClientEndpointBehavior(tp);
            Binding binding;
            switch (protocol)
            {
               case "sb":
                  binding = new NetTcpRelayBinding { TransferMode = TransferMode.Streamed, MaxReceivedMessageSize = 1048576000, MaxBufferSize = 10485760, MaxConnections = 200 };
                  break;
               case "http":
                  binding = new BasicHttpBinding { TransferMode = TransferMode.Streamed, MaxReceivedMessageSize = 1048576000, MaxBufferSize = 10485760 };
                  break;
               case "https":
                  var wsbinding = new WS2007HttpRelayBinding { MaxReceivedMessageSize = 1048576000 };
                  wsbinding.Security.Mode = EndToEndSecurityMode.Transport;
                  wsbinding.Security.RelayClientAuthenticationType = RelayClientAuthenticationType.None;
                  binding = wsbinding;
                  break;
               default:
                  throw new NotSupportedException("Protocol not supported: " + protocol);
            }
            var serviceEndPoint = _host.AddServiceEndpoint(typeof(IInstalSoftCloudService), binding, uri);
            serviceEndPoint.Behaviors.Add(sharedSecretServiceBusCredential);
            // Lines below are for MEX and publishing of the service
            EnableMetadataExchange(uri, sharedSecretServiceBusCredential, binding);
            ServiceRegistrySettings serviceRegistrySettings = new ServiceRegistrySettings(DiscoveryType.Public) { DisplayName = "InstalSystemMobileEngine" };
            foreach (ServiceEndpoint subscriberEndpoint in _host.Description.Endpoints)
            {
               subscriberEndpoint.Behaviors.Add(serviceRegistrySettings);
            }
            _host.Open();
            Trace.WriteLine("Service initialization completed");
         }
         catch (Exception e)
         {
            Trace.WriteLine("Service initialization failed.\r\n" + e.Message);
            throw; 
         }
      }
      private void EnableMetadataExchange(Uri aBaseUri, TransportClientEndpointBehavior aBehavior, Binding aBinding, bool aEnableHttpGet = true)
      {
         if (_host.State == CommunicationState.Opened)
            throw new InvalidOperationException("Host already opened");
         var metadataBehavior = _host.Description.Behaviors.Find<ServiceMetadataBehavior>();
         if (metadataBehavior == null)
         {
            metadataBehavior = new ServiceMetadataBehavior();
            _host.Description.Behaviors.Add(metadataBehavior);
            Trace.WriteLine("_host.Description.Behaviors.Add(metadataBehavior)");
         }
         var mexEndpoint = _host.AddServiceEndpoint(typeof(IMetadataExchange), aBinding, new Uri(aBaseUri, "mex"));
         mexEndpoint.Behaviors.Add(aBehavior);
      }
