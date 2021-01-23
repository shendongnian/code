     public class CommonAppController : Controller
     {
         protected CommonAppController()
         {
             ViewBag.Common = new AppModel("en");
         }
     }
     public class RegisterController : CommonAppController
     { //...
