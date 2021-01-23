    public class MyAuthenticationModule : IAuthenticationModule
    {
        internal const string TheAuthenticationType = "MyAuthentication";
        private readonly CredentialCache _credentialCache = new CredentialCache();
        private readonly Uri _loginServerUrl;
        internal CredentialCache CredentialCache
        {
            get
            {
                return _credentialCache;
            }
        }
        internal Uri LoginServerUrl
        {
            get
            {
                return _loginServerUrl;
            }
        }
        internal MyAuthenticationModule(Uri loginServerurl)
        {
            if (loginServerurl == null)
            {
                throw new ArgumentNullException("loginServerUrl");
            }
            _loginServerUrl = loginServerurl;
        }
        public Authorization Authenticate(string challenge, WebRequest request, ICredentials credentials)
        {
            Authorization result = null;
            if (request == null || credentials == null)
            {
                result = null;
            }
            else
            {
                NetworkCredential creds = credentials.GetCredential(LoginServerUrl, TheAuthenticationType);
                if (creds == null)
                {
                    return null;
                }
                ICredentialPolicy policy = AuthenticationManager.CredentialPolicy;
                if (policy != null && !policy.ShouldSendCredential(LoginServerUrl, request, creds, this))
                {
                    return null;
                }
                string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", creds.UserName, creds.Password)));
                result = new Authorization(string.Format("Basic {0}", token));
            }
            return result;
        }
        public string AuthenticationType
        {
            get { return TheAuthenticationType; }
        }
        public bool CanPreAuthenticate
        {
            get { return false; }
        }
        public Authorization PreAuthenticate(WebRequest request, ICredentials credentials)
        {
            return null;
        }
    }
