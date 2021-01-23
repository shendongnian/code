        [HttpPost]
        public ActionResult Admin_Mgmt(List<thing> things, int Action_Code)
        {
            switch (Action_Code)
            {
                case 1: 
                    {   //redirecting requesting to another controller 
                        TempData["Things"]=things; //transferring list into tempdata 
                        return RedirectToAction("Quran_Loading", "Request_Handler",things);
                    }
               default:
                       ...
            }
        }
    public class Request_HandlerController : Controller
    {
        public ActionResult Quran_Loading()
        {
            List<thing> things=TempData["Things"] as  List<thing>;
         }
    }
