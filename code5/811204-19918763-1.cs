    public class GluAuthenticationFilter : BasicAuthenticationFilter
        {
            [Inject]
            public IAuthenticationService AuthenticationService { get; set; }
    
            public GluAuthenticationFilter()
            { }
    
            public GluAuthenticationFilter(bool active)
                : base(active)
            { }
    
    
            protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
            {
                return AuthenticationService.Authenticate(username, password);
            }
        }
