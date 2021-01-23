    public class PlanDetailsController : Controller
    {      
        [HttpPost]
        public async Task<ActionResult> Generate(PlanDetailsVM planDetailsVM) 
        {
           System.Diagnostics.Debug.WriteLine("controller 1");
           //calls business method to generate                       
           var task = Task.Run(() => _planDesignBS.GenerateBS(planDetailsVM));
           System.Diagnostics.Debug.WriteLine("controller 2");
            var quoteId = await task;
            return Json(quoteId , JsonRequestBehavior.AllowGet);
        }
    }
