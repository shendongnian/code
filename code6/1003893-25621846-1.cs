    [Authorize]
    public class ProgramB:Controller
       {
    
         public ActionResult Method1()
         {
           return View();
         }
    
         [Authorize]
         public ActionResult Method2()
         {
           return View();
         }
       }
