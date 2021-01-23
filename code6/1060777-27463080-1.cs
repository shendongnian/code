    public class TestController : Controller
    {
        [Route("api/test")]
        public JsonResult Date()
        {
            return Json(new { result = 1, currentDate = DateTime.UtcNow }, JsonRequestBehavior.AllowGet);
        }
    }
