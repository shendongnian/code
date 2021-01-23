    public class TestController : Controller {
         public ActionResult PostToAccount(string someData) {
           var accountModel = new AccountModel();
           accountModel.Feed = feed;
           return View("~/Views/Test/Index.cshtml", accountModel);
         }
    }
