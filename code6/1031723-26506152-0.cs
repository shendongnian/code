    using VehicleAudits2_v1.classes;
        
    public class SomeController : Controller
    {
        
      public ActionResult SomeAction()
      {
        ConvertImage convert = new ConvertImage();
        convert.base64ToImage("SomeValue");
        return View();
        
      }
    
    }
