    public class MyController : Controller
    {
        private readonly DbContext context;
        public MyController()
        {
            this.context = new DbContext();
        }
        // rest of actions reference `context.<whatever>`
    }
