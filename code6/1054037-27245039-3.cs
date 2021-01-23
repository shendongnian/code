    public class RoleManagerFactory
    {
        private readonly IDbContextFactory<SomeContext> contextFactory
        public RoleManagerFactory(IDbContextFactory<SomeContext> contextFactory)
        {
             this.contextFactory = contextFactory;
        }
        public RoleManager<IdentityRole> Create()
        {
            return new RoleManager<IdentityRole>(new RoleStore<IdentityRole, string>(contextFactory.Create()));
        }
        // If you have already instantiated a context to use, then you can pass it in here
        public RoleManager<IdentityRole> Create(SomeContext context)
        {
            return new RoleManager<IdentityRole>(new RoleStore<IdentityRole, string>(context));
        }
    }
    
    var factory = new RoleManagerFactory();
    app.CreatePerOwinContext<RoleManager<IdentityRole>>(factory.Create());
