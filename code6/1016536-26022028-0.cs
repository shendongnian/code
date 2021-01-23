       public class MyModel
        {
           public string Identity {get;set;}
        }
    
        public class MyController : BaseController
        {
        
            public ActionResult Get()
            {
               var myModel = new MyModel();
               myModel.Identity = System.Web.HttpContext.Current.User.Identity.Name;
        
               //snip
               return View(myModel);
            }
        }
