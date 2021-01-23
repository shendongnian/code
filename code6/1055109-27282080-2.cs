        public class ApplicationRoleManager : RoleManager<IdentityRole, string>
        {
            public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
                : base(roleStore)
            {
            }
    
            public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
            {
                return new ApplicationRoleManager(new RoleStore<IdentityRole, string, IdentityUserRole>(context.Get<ApplicationDbContext>()));
            }
        }
