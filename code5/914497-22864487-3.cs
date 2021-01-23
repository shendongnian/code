    public class AddressController : MyBaseController
    {
        public JsonResult Validate(Address model)
        {
             //validate logic!      
             return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
