    public class MyController: Controller //or ApiController
    {
        public Func<string> GetUserId; //For testing
        public MyController()
        {
            GetUserId = User.Identity.GetUserId;
        }
        //controller actions
    }
