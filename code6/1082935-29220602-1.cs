    namespace YourProject.Controllers
    {
        public class UserManagementController : Controller
        {
            private UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())){EmailService = new Services.EmailService()};
            // GET: UserManagement
