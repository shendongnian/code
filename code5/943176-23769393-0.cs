    public static class ServiceClientFactory
    {
        public static HttpBindingBase BuildBinding(string endpointUrl)
        {
            if (endpointUrl.ToLower().StartsWith("https"))
            {
                var binding = new BasicHttpsBinding(BasicHttpsSecurityMode.Transport);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
                binding.MaxReceivedMessageSize = int.MaxValue - 1;
                return binding;
            }
            else
            {
                var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;
                binding.MaxReceivedMessageSize = int.MaxValue - 1;
                return binding;
            }
        }
        public static TClient CreateClient<TClient, TChannel>(string endpoint, string username, string password)
            where TClient : ClientBase<TChannel>
            where TChannel : class
        {
            var client = (TClient)
                Activator.CreateInstance(
                    typeof (TClient),
                    BuildBinding(endpoint),
                    new EndpointAddress(endpoint));
            if (null == client.ClientCredentials)
                throw new Exception(
                    string.Format("Error initializing [{0}] client.  Client Credentials object was null",
                        typeof(TClient).Name));
            
           //This is for setting Basic Auth
           client.ClientCredentials.Windows.ClientCredential =
                new NetworkCredential(
                    username,
                    password);
            client.ClientCredentials.Windows.AllowedImpersonationLevel =
                TokenImpersonationLevel.Delegation;
           return client;
        }
    }
}
