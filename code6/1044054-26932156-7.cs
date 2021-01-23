    public class UserTokenAuthenticationAttribute : AuthorizeAttribute
    {
        private ILoginService _loginService;
        
		// This is the magic part - Unity reads this attribute and sets injects the related property. This means no parameters are required in the constructor.
        [Microsoft.Practices.Unity.Dependency]
        public ILoginService LoginService
        { 
            get
            {
                return this._loginService;
            } 
            set
            {
                this._loginService = value;
            }  
        }
        
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            // Authorise code goes here using injected this._loginService
        }
    }	   
