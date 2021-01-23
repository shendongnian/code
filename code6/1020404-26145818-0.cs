    public partial class App : Application
    {
        public App()
        {
            Current.Startup += CurrentOnStartup;
        }
        private void CurrentOnStartup(object sender, StartupEventArgs startupEventArgs)
        {
            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            AuthenticationManager.CredentialPolicy = new ProxyCredentials();
        }
    }
    internal class ProxyCredentials : ICredentialPolicy
    {
        bool ICredentialPolicy.ShouldSendCredential(Uri challengeUri, WebRequest request, NetworkCredential credential,
            IAuthenticationModule authenticationModule)
        {
            return true;
        }
    }
