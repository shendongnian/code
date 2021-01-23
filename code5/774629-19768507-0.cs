    public class HomeController : Controller
    {
        private DataContext db = new DataContext();
        public JsonResult GetCustomer(int id)
        {
            try
            {
                var customerRecord = db.CustomerList.Find(id);
                return Json(new { Result = "OK", Records = customerRecord }, JsonRequestBehavior.AllowGet);
            }catch(Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
