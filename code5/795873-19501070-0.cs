    [Authorize]
    public class ConfirmController : Controller {
    
      [AllowAnonymous]  
      public ActionResult ConfirmToken(string id)
      {
       //..
      }
    
    }
