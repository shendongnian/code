     public class HomeController : Controller
        {
            public static List<UserInfo> Users = null; 
            
            //
            // GET: /Home/
            
            public ActionResult Index()
            {
                return View(Users);
            }
    
            public ActionResult Create()
            {
                return View();
            }
    
            [HttpPost]
            public ActionResult Create(UserInfo userInfo)
            {
                if (ModelState.IsValid)
                {
                    Users.Add(userInfo);
                    return RedirectToAction("Index");
                }
                return View();
            }
    
        }
