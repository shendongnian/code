                CustomBinding binding = new CustomBinding();
                binding.Name = "ClearUsernameBinding_IUserDetailsService";
                
                binding.SendTimeout = TimeSpan.FromMinutes(2);
                binding.OpenTimeout = TimeSpan.FromMinutes(2);
                binding.CloseTimeout = TimeSpan.FromMinutes(2);
                binding.ReceiveTimeout = TimeSpan.FromMinutes(10);
                binding.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap11, System.Text.Encoding.UTF8));
                binding.Elements.Add(TransportSecurityBindingElement.CreateUserNameOverTransportBindingElement());
                binding.Elements.Add(new HttpsTransportBindingElement());
                               
                EndpointAddress endpoint = new EndpointAddress(new Uri("https://MYURL"));
                ServiceReference1.UserDetailsServiceClient proxy = new ServiceReference1.UserDetailsServiceClient(binding, endpoint);
                proxy.Endpoint.Contract.Name = "IScheduledVisitsService";
                proxy.Endpoint.Contract.ConfigurationName = "ClearUsernameBinding_IScheduledVisitsService";
                proxy.Endpoint.Address = endpoint;
                proxy.Endpoint.Binding = binding;
                proxy.ClientCredentials.UserName.UserName = Loginmodel.UserName;
                proxy.ClientCredentials.UserName.Password = Loginmodel.Password;
                UserDTO result = await proxy.GetUserByUsernameAsync(Loginmodel.UserName);
