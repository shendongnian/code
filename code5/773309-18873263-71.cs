    public class AccountsController: Controller
    {
       public ActionResult Login()
       {
           // shows login page.
           return View();
       }
       public ActionResult Home()
       {
           // shows home page. Make sure you have Accounts\Home.cshtml view.
           return View();
       }
       [HttpPost]
       public ActionResult Login(UserLogin model)
       {
          // if credentials are correct.
          if (accountsService.Login(model)) 
          {
              // redirect to home page.
              return View("Home");
          } 
          else 
          {
              // show login page again.
              return View();
          }          
       }
    }
