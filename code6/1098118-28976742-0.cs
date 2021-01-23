    public class User : IUserIdentity
    {
        private readonly ClaimsPrincipal claimsPrincipal;
        public User(ClaimsPrincipal claimsPrincipal)
        {
            this.claimsPrincipal = claimsPrincipal;
        }
        public string UserName { get { return claimsPrincipal.Identity.Name; } }
        public IEnumerable<string> Claims { get { return claimsPrincipal.Claims.Select(c => c.ToString()); } }
    }
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.BeforeRequest += ctx =>
            {
                ctx.CurrentUser = new User(Thread.CurrentPrincipal as ClaimsPrincipal);
                return null;
            };
        }
    }
