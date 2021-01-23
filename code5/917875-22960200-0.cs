    public class ValidationController : Controller 
    {
    
      public JsonResult IsAddressValid(string Address) 
      {
    
         //if Address is valid
         return Json(true, JsonRequestBehavior.AllowGet);
        //else
       return Json("Address Not valid", JsonRequestBehavior.AllowGet);
      }
    }
