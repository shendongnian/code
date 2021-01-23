    public class ExternalCredentialsRepository
    {
        private readonly string webUrl;
    
        public ExternalCredentialsRepository(string webUrl)
        {
            this.webUrl = webUrl;
        }
    
        public NetworkCredential GetCredentials(string applicationId)
        {
            var credentialMap = new Dictionary<string, string>();
    
            using (var site = new SPSite(webUrl))
            {
                var serviceContext = SPServiceContext.GetContext(site);
                var secureStoreProvider = new SecureStoreProvider {Context = serviceContext};
    
                using (var credentials = secureStoreProvider.GetCredentials(applicationId))
                    PopulateCredentialsMap(secureStoreProvider, credentials, applicationId, credentialMap);
            }
    
            string userName = credentialMap["Windows User Name"];
            string domain = credentialMap["Windows Domain"];
            string password = credentialMap["Windows Password"];
    
            return new NetworkCredential(userName, password, domain);
        }
    
        private static void PopulateCredentialsMap(SecureStoreProvider secureStoreProvider, SecureStoreCredentialCollection credentials, string applicationId, Dictionary<string, string> credentialMap)
        {
            var fields = secureStoreProvider.GetTargetApplicationFields(applicationId);
    
            for (var i = 0; i < fields.Count; i++)
            {
                var field = fields[i];
                var credential = credentials[i];
                var decryptedCredential = ExtractString(credential.Credential);
    
                credentialMap.Add(field.Name, decryptedCredential);
            }
        }
    
        private static string ExtractString(SecureString secureString)
        {
            var ptr = Marshal.SecureStringToBSTR(secureString);
    
            try
            {
                return Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                Marshal.FreeBSTR(ptr);
            }
        }
    }
