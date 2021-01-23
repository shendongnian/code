    [Route("api/test")]
    public class TestController : Controller
    {
      [HttpGet("date")]
      public JsonResult Date()
      {
        return Json(new { result = 1, currentDate = DateTime.UtcNow }, JsonRequestBehavior.AllowGet);   
      }
    }
