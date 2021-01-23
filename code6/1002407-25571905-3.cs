    public class MyController : Controller
        {
            private readonly IMyService blogService;
            public MyController(IMyService blogService)
            {
                this.blogService= blogService;
            }
    
            public ActionResult SaveRecord(FormCollection formStuff)
            {
            if (ModelState.IsValid)
            {
                 try
                 {
                     this.blogService.CreateBlog(formStuff);
                 }
        
            }
        
            }
        }
