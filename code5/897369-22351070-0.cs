    public class Program
    {
        public static void Main()
        {
            var baseAddress = new Uri("https://localhost:8080/SelfHostedUsernamePasswordService");
            using (var host = new ServiceHost(typeof(SelfHostedUsernamePasswordService), baseAddress))
            {
                var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
                binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
                var endpoint = host.AddServiceEndpoint(typeof(ISelfHostedUsernamePasswordService), binding, baseAddress);
                var cf = new ChannelFactory<ISelfHostedUsernamePasswordService>(binding, endpoint.Address);
                cf.Credentials.ClientCertificate.SetCertificate(
                    StoreLocation.LocalMachine,
                    StoreName.My,
                    X509FindType.FindByThumbprint,
                    "0000000000000000000000000000000000000000");
                var credentialBehavior = new ServiceCredentials();
                credentialBehavior.UserNameAuthentication.CustomUserNamePasswordValidator = new UsernamePasswordValidator();
                credentialBehavior.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
                credentialBehavior.IssuedTokenAuthentication.AllowUntrustedRsaIssuers = true;
                host.Description.Behaviors.Add(credentialBehavior);
                var metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpsGetEnabled = true;
                metadataBehavior.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(metadataBehavior);
                host.Open();
                Console.WriteLine("The service is ready at {0}", baseAddress);
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
                host.Close();
            }
        }
    }
    public class UsernamePasswordValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (!string.Equals(userName, "admin", StringComparison.OrdinalIgnoreCase) ||
                !string.Equals(password, "password", StringComparison.Ordinal))
            {
                Console.WriteLine("Validation failed.");
                throw new SecurityTokenException("Validation failed.");
            }
            Console.WriteLine("Validation successful.");
        }
    }
