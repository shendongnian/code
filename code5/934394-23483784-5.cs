    [RoutePrefix("Lorem/Ipsum/Task")]
    public class LoremController : Controller
    {
       [Route("Increment"), HttpPost]
       public JsonResult Increment(int id)
       {
          try
          {
             // Increment your task count!
             return Json(new { Success = true, ErrorMessage = "" });
          }
          catch(Exception err)
          {
             return Json(new { Success = false, ErrorMessage = err.Message });
          }
       }
    }
