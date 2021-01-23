    class Program
    {
        static void Main()
        {
            var remoteAddress = new EndpointAddress(new Uri("https://localhost:8080/SelfHostedUsernamePasswordService"));
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
            using (var client = new SelfHostedUsernamePasswordServiceClient(binding, remoteAddress))
            {
                client.ClientCredentials.UserName.UserName = "admin";
                client.ClientCredentials.UserName.Password = "password";
                var result = client.GetData(12345);
                Console.WriteLine("Got result from service: {0}", result);
                Console.ReadLine();
                client.Close();
            }
        }
    }
