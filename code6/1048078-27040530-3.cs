    public class MyController : Controller
    {
        public ActionResult Index
        {
            var myViewModel = new MyViewModel 
                 {
                     Post = post,
                     Comment = comment // assumed that these have been read from a DB
                 };
    
            return View(myViewModel);
        }
    }
