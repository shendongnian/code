        public class BaseController : Controller
        {
            public BaseController()
            {
                this.SetCurrentCulture();
            }
        
            private void SetCurrentCulture()
            {
               If(String.IsNullOrEmpty(MySession.Language))
                  MySession.Language="en-US";
               CultureInfo ci = new CultureInfo(MySession.Language);
               System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
               System.Threading.Thread.CurrentThread.CurrentCulture = ci;
            }
        
            public ActionResult ChangeLanguage(string language)
            {
               MySession.Language=language;
               this.SetCurrentCulture();
               return View();//or something 
            }
        }
    
    
       public class MyController:BaseController
       {
       }
