    public class HomeController : Controller
        {
            // GET: Home
            public async Task<ActionResult> Index()
            {
                var context = new ApplicationDbContext(); // DefaultConnection
                var store = new UserStore<student>(context);
                var manager = new UserManager<student>(store);
                var signInManager = new SignInManager<student, string>(manager,
                    HttpContext.GetOwinContext().Authentication);
                var username  = "Edward";
                var email = "abc@gmail.com";
                var password = "Your password";
                var user = await manager.FindByEmailAsync(email);
    
                if (user == null)
                {
                    user = new student                    {
                        UserName = username,//username ,Email are getting from identityDbContext and the other three RollNO,FirstName and LastName are your own Custom members.so like this you can extend your any kind of data you like add or extend with IdentityDbContext.
                        Email = email,
                        RollNo = "15",
                        FirstName = "David",
                        LastName = "Kandel"
                    };
    
                    await manager.CreateAsync(user, password);
                }
                else
                {
                    var result = await signInManager.PasswordSignInAsync(user.UserName, password, true, false);
    
                    if (result == SignInStatus.Success)
                    {
                        return Content("Hello, " +user.rollno + ""  + user.FirstName + " " + user.LastName);
                    }
                        
                                    }
    
    
                return Content("Hello, Index");
            }
        }
> 
