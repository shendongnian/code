    using Microsoft.AspNet.Identity;
    
    [Authrorize]
    public class AdminController : Controller{
     /* do your stuff in here. If your View is not actually a big difference from the tester view and you will only Hide some objects from the tester or viceversa, I suggest you use the same View but make a different methods inside the Controller. Actually you don't need to make AdminController and Tester Controller at all. */
    }
    // you can just do this in one Controller like
    [Authorize(Roles="Admin")]
    public ActionResult DetailsForAdmin(int id)
    {
        var myRole = db.MyModelsAccounts.Find(id);
        return View("Admin", myRole);  //<- Admin returning View
    }
    [Authorize(Roles="Test")]
    public ActionResult DetailsForTester
    I think you get the Idea.
