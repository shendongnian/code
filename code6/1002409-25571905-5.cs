    public class MyController : Controller
    {
        private readonly IDbContextFactory<BlogDb> blogContextFactory;
        public MyController(IDbContextFactory<BlogDb> blogContextFactory)
        {
            this.blogContextFactory = blogContextFactory;
        }
    }
    
    then in your method you should be disposing of the context properly:
    
    public ActionResult SaveRecord(FormCollection formStuff)
    {
        if (ModelState.IsValid)
        {
             try
             {
                 using ( var context = blogContextFactory.Create())
                 {
                     // do you stuff here!
                 }
             }
    
        }
    
    }
