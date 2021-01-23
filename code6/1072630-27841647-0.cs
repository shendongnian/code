    public class CustomAuthProvider : AuthProvider
    {
        public CustomAuthProvider()
        {
            this.Provider = "custom";
        }
        public override bool IsAuthorized(
            IAuthSession session, IAuthTokens tokens, Authenticate request=null)
        {
            return true; //custom logic to verify if this session is authenticated
        }
        public override object Authenticate(
            IServiceBase authService, IAuthSession session, Authenticate request)
        {
            throw new NotImplementedException();
        }
    }
    Plugins.Add(new AuthFeature(() => new CustomUserSession(),
        new IAuthProvider[] {
            new CustomAuthProvider()
		}));
