     public class PlanDetailsController : Controller
        {      
            [HttpPost]
            public async Task<ActionResult> Generate(PlanDetailsVM planDetailsVM) 
            {
               System.Diagnostics.Debug.WriteLine("controller 1");
               //calls business method to generate                       
               var quoteIdTask =  GenerateAsyncBs();
        
               System.Diagnostics.Debug.WriteLine("controller 2");
    
    int id = await quoteIdTask;
        
                return Json(quoteId , JsonRequestBehavior.AllowGet);
            }
        }
        
        private async Task<int> GenerateBsAsync()
        {
          //do your planDetails logic here.
        }
