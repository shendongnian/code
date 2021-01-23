    public class RoleController : Controller
    {
        private readonly IRoleManagerFactory roleManagerFactory;
    
        public RoleController (IRoleManagerFactory roleManagerFactory)
        {
             this.roleManagerFactory = roleManagerFactory;
        }
    
        // Create method
        public async Task<JsonResult> CreateRole(string role)
        {
            using (var roleManager = this.roleManagerFactory.Create())
            {
                var result = await roleManager.CreateAsync(role);
    
                return Json(new { succeeded: result.Succeeded });
            }
        }
    }
