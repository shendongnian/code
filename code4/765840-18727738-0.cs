    public class CustomUserSession : AuthUserSession
    {
        public CustomUserSession()
        {
            this.Log = LogManager.GetLogger(this.GetType());
            this.Repository = EndpointHost.AppHost.TryResolve<IRepository>();
        }
        protected IRepository Repository { get; set; }
        protected ILog Log { get; set; }
        public string CustomProperty { get; set; }
        public override void OnAuthenticated(IServiceBase authService, IAuthSession session, IOAuthTokens tokens, Dictionary<string, string> authInfo)
        {
            this.CustomProperty = this.Repository.GetCustomProperty(session.UserAuthName);
            var otherRepository = authService.TryResolve<IOtherRepository>();
            session.Permissions.AddRange(otherRepository.GetPermissions(session.UserAuthId));
            // etc.....
            base.OnAuthenticated(authService, session, tokens, authInfo);
        }
        public override void OnRegistered(IServiceBase registrationService)
        {
            this.Log.WarnFormat(
                "OnRegistered - queue a registered event/email/notification");
            base.OnRegistered(registrationService);
        }
    }
