    public class RoleManagerFactory
    {
        public RoleManager<IdentityRole> Create()
        {
            return new RoleManager<IdentityRole>(new RoleStore<IdentityRole, string>());
        }
    }
    
    var factory = new RoleManagerFactory();
    app.CreatePerOwinContext<RoleManager<IdentityRole>>(factory.Create());
