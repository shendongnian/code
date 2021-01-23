    public class AlertsController : Controller 
    {
       public ActionResult Show()
       {
         var model = GetModel();//decide where this will come from.
    
         return PartialView("~/Views/Shared/_Alerts.cshtml",model);
       }
    
    }
