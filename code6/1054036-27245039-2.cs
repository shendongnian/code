    public class RoleController : ApiController
    {
        private readonly IRoleManagerFactory roleManagerFactory;
    
        public RoleController (IRoleManagerFactory roleManagerFactory)
        {
             this.roleManagerFactory = roleManagerFactory;
        }
    
        // Create method
        public async Task<bool> Post(string role)
        {
            using (var roleManager = this.roleManagerFactory.Create())
            {
                var result = await roleManager.CreateRoleAsync(role);
    
                return result.Succeeded;
            }
        }
    }
