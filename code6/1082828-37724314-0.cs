     public class BasicAuthenticator : IAuthenticator
        {
            private readonly string _baseUrl;
            private readonly string _userName;
            private readonly string _password;
            private readonly CredentialCache _credentialCache;
    
            public BasicAuthenticator(string baseUrl, string userName, string password)
            {
                _baseUrl = baseUrl;
                _userName = userName;
                _password = password;
    
                _credentialCache = new CredentialCache
                {
                    {new Uri(_baseUrl), "Basic", new NetworkCredential(_userName, _password)}
                };
            }
    
            public void Authenticate(IRestClient client, IRestRequest request)
            {
                request.Credentials = _credentialCache;
    
                if (request.Parameters.Any(parameter =>
                                parameter.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
                {
                    return;
                }
                request.AddParameter("Authorization", GetBasicAuthHeaderValue(), ParameterType.HttpHeader);
            }
    
            
            private string GetBasicAuthHeaderValue()
            {
                return string.Format("Basic {0}",
                                Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}",
                                    _userName, _password))));
            }
        }
