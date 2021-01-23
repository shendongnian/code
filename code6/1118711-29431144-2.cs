    public class AzureAdAuthenticationProvider
    {
        private const string AppPasswordRequiredErrorCode = "50076";
        private const string AuthorityFormatString = "https://login.windows.net/{0}";
        private const string GraphResource = "https://graph.windows.net";
        private AuthenticationContext _authContext;
        private string _clientId;
        public AzureAdAuthenticationProvider()
        {
            var tenantId = "..."; // Get from configuration
            _authContext = new AuthenticationContext(string.Format(AuthorityFormatString, tenantId));
        }
        public bool Authenticate(string user, string pass)
        {
            try
            {
                _authContext.AcquireToken(GraphResource, _clientId, new UserCredential(user, pass));
                return true;
            }
            catch (AdalServiceException ase)
            {
                return ase.ServiceErrorCodes.All(sec => sec == AppPasswordRequiredErrorCode);
            }
            catch (Exception)
            {
                return false; // Probably needs proper handling
            }
        }
    }
