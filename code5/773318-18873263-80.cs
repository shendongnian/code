    public class AccountsController: Controller
    {
       public ActionResult Login()
       {
           // shows login page.
           return View();
       }
       [HttpPost]
       public ActionResult Login(UserLogin model)
       {
          if (CheckCredentials(model)) 
          {
              // login user logic here.
              // redirect to home page.
              return View("Home");
          }
          // show login page again.
          return View(model);
       }
    }
