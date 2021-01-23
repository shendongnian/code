    public class MyAccountController : Controller
    {
        [Authorize(Roles = "Admin")]
        public ActionResult User1()
        {
           // do user1 work
        }
    
        [Authorize]
        public ActionResult User2()
        {
           // do user2 work
        }
    }
