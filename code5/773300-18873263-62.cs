    public class AccountsController: Controller
    {
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
