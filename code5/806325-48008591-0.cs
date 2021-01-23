     var binding = new BasicHttpBinding();
            binding.ProxyAddress = new Uri(string.Format("http://{0}:{1}", proxyAddress, proxyPort));
            binding.UseDefaultWebProxy = false;
            binding.Security.Mode = BasicHttpSecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            binding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.Basic;
            var endpoint = new EndpointAddress("serviceadress");
            var authenticationClient = new WOKMWSAuthenticateClient(binding, endpoint);
            authenticationClient.ClientCredentials.UserName.UserName = username;
            authenticationClient.ClientCredentials.UserName.Password = password;
            
