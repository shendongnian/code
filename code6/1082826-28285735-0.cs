    public class MyAuthenticator : IAuthenticator
    {
        private readonly CredentialCache _credentials = new CredentialCache();
        public MyAuthenticator(Uri loginServerUrl, string username, string password)
        {
            if (loginServerUrl == null)
            {
                throw new ArgumentNullException("loginServerUrl");
            }
            __registerAuthenticationModule(loginServerUrl);
            _credentials.Add(loginServerUrl, MyAuthenticationModule.TheAuthenticationType, new NetworkCredential(username, password, loginServerUrl.Host));
        }
        private static MyAuthenticationModule __registerAuthenticationModule(Uri loginServerUrl)
        {
            IEnumerator registeredModules = AuthenticationManager.RegisteredModules;
            MyAuthenticationModule authenticationModule;
            while (registeredModules.MoveNext())
            {
                object current = registeredModules.Current;
                if (current is MyAuthenticationModule)
                {
                    authenticationModule = (MyAuthenticationModule)current;
                    if (authenticationModule.LoginServerUrl.Equals(loginServerUrl))
                    {
                        return authenticationModule;
                    }
                }
            }
            authenticationModule = new MyAuthenticationModule(loginServerUrl);
            AuthenticationManager.Register(authenticationModule);
            return authenticationModule;
        }
        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.Credentials = _credentials;
        }
    }
