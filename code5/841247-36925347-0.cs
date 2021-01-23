    Uri organizationUriIFD = new Uri("https://[server]:[port]/XRMServices/2011/Organization.svc");
    
    ClientCredentials credentials = new ClientCredentials();
    credentials.UserName.UserName = "username";
    credentials.UserName.Password = "password";
    
    IServiceConfiguration<IOrganizationService> config = ServiceConfigurationFactory.CreateConfiguration<IOrganizationService>(organizationUriIFD);
    
    using (Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy _serviceProxy = new OrganizationServiceProxy(config, credentials))
    {
      // This statement is required to enable early-bound type support.
      _serviceProxy.ServiceConfiguration.CurrentServiceEndpoint.Behaviors.Add(new ProxyTypesBehavior());
    
      IOrganizationService _service = (IOrganizationService)_serviceProxy;
    
      WhoAmIResponse response = (WhoAmIResponse)_service.Execute(new WhoAmIRequest());
      Console.WriteLine(response.UserId.ToString());
    
      Console.ReadLine();
    }
