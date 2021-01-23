	WebServiceHost secureHost
	secureHost.Credentials.UserNameAuthentication.UserNamePasswordValidationMode = UserNamePasswordValidationMode.Custom;
	secureHost.Credentials.UserNameAuthentication.CustomUserNamePasswordValidator = new ClientValidator(username, password);
	// Need to reference System.IdentityModel
    public class ClientValidator : UserNamePasswordValidator
    {
        private readonly string _password;
        private readonly string _username;
        public ClientValidator(string username, string password)
        {
            _password = password;
            _username = username;
        }
        public override void Validate(string userName, string password)
        {
            if (userName != _username || (password != _password))
            {
                WebFaultException rejectEx = new WebFaultException(HttpStatusCode.Unauthorized);
                rejectEx.Data.Add("HttpStatusCode", rejectEx.StatusCode);
                throw rejectEx;
            }
        }
    }
