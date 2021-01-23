     var id = new EntityInstanceId
     {
         Id = new Guid("682f3258-48ff-e211-857a-2c27d745b005")
     };
     var endpoint = new EndpointAddress(new Uri("http://server/XRMDeployment/2011/Deployment.svc"),
                        EndpointIdentity.CreateUpnIdentity(@"DOMAIN\DYNAMICS_CRM"));
     var login = new ClientCredentials();
     login.Windows.ClientCredential = CredentialCache.DefaultNetworkCredentials;
     
     var binding = new CustomBinding();
     
     //Here you may config your binding (example in the link at the bottom of the post)
     var client = new DeploymentServiceClient(binding, endpoint);
     foreach (var credential in client.Endpoint.Behaviors.Where(b => b is ClientCredentials).ToArray())
     {
         client.Endpoint.Behaviors.Remove(credential);
     }
     
     client.Endpoint.Behaviors.Add(login);
     var organization = (Organization)client.Retrieve(DeploymentEntityType.Organization, id);
