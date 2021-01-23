         public class ErrorController : Controller {
             publc ActionResult NotFound()
             {
               Return View();
              }
          }
          <customErrors mode="On">
             <error statusCode="404" redirect="~/Error/NotFound"/>
          </customErrors>
