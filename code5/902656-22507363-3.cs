     public class ErrorController : Controller
        {
            /// <summary>
            /// Action Method for Rendering Error View upon Error Occurance
            /// </summary>
            /// <returns></returns>
            public ActionResult Error()
            {
                return View();
            }
        }
