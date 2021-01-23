    var clientUrl = new Uri(string.Format("{0}://{1}:{2}/{3}", protocol, ip, port, serviceAddress + clientId));
    var contractDescription = ContractDescription.GetContract(typeof(TServiceInterface));
    var host = new ServiceHost(typeof(TServiceImplementation), clientUrl);
     var serviceBehaviorAttribute = new ServiceBehaviorAttribute();
     serviceBehaviorAttribute.AddressFilterMode = AddressFilterMode.Any; // Important
     serviceBehaviorAttribute.ConcurrencyMode = ConcurrencyMode.Multiple; 
     serviceBehaviorAttribute.InstanceContextMode = InstanceContextMode.PerCall;
     host.Description.Behaviors.Remove<ServiceBehaviorAttribute>();
     host.Description.Behaviors.Add(serviceBehaviorAttribute);
     var serviceMetadataBehavior = new ServiceMetadataBehavior();
     serviceMetadataBehavior.HttpGetEnabled = false;
     serviceMetadataBehavior.HttpsGetEnabled = true;
     host.Description.Behaviors.Remove<ServiceMetadataBehavior>();
     host.Description.Behaviors.Add(serviceMetadataBehavior);
     var serviceDebugBehavior = new ServiceDebugBehavior();
     serviceDebugBehavior.IncludeExceptionDetailInFaults = true;
     host.Description.Behaviors.Remove<ServiceDebugBehavior>();
     host.Description.Behaviors.Add(serviceDebugBehavior);
     var requestHeaderBehavior = new UseRequestHeadersForMetadataAddressBehavior(); // Important
     host.Description.Behaviors.Remove<UseRequestHeadersForMetadataAddressBehavior>();
     host.Description.Behaviors.Add(requestHeaderBehavior);
 
    host.AddServiceEndpoint(new ServiceEndpoint(
                contractDescription,
                new InternalBinding(),
                new EndpointAddress(clientUrl, EndpointIdentity.CreateX509CertificateIdentity(serviceCertificate))));
    host.Open();
