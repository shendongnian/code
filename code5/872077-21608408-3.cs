    public class MyController : Controller
    {
        private readonly DbContext context;
        public MyController(DbContext context)
        {
            this.context = context;
        }
        // rest of actions reference `context.<whatever>`
    }
