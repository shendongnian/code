    using System.Security.Cryptography.X509Certificates;
    using System.Threading;
    using System.Threading.Tasks;
    using Google.Apis.Auth.OAuth2;
    
    namespace GoogleTest
    {
        public class GoogleOAuth2
        {
            /// <summary>
            /// Authorization scope for our requests
            /// </summary>
            private readonly string _defaultScope;
    
            /// <summary>
            /// Service account will be of the form nnnnnnn@developer.gserviceaccount.com
            /// </summary>
            private readonly string _serviceAccount;
    
            /// <summary>
            /// Set this to the full path to your service account private key file.
            /// </summary>
            private readonly string _certificateFile;
    
            public GoogleOAuth2(string defaultScope, string serviceAccount, string certificateFile)
            {
                _defaultScope = defaultScope;
                _serviceAccount = serviceAccount;
                _certificateFile = certificateFile;
            }
    
            /// <summary>
            /// Access Token returned by Google Token Server
            /// </summary>
            public string AccessToken { get; set; }
    
            public async Task<bool> RequestAccessTokenAsync()
            {
                var certificate = new X509Certificate2(_certificateFile, "notasecret", X509KeyStorageFlags.Exportable);
                var serviceAccountCredential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(_serviceAccount)
                {
                    Scopes = new[] { _defaultScope }
                }.FromCertificate(certificate));
    
                var status = await serviceAccountCredential.RequestAccessTokenAsync(CancellationToken.None);
                if (status)
                    AccessToken = serviceAccountCredential.Token.AccessToken;
                return status;
            }
        }
    }
