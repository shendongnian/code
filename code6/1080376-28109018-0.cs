    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
    
            BaseValidationContainer = new ValidationContainer();
    
            BaseValidationContainer.AddMessage(MessageTypeEnum.Error, "Error");
            BaseValidationContainer.AddMessage(MessageTypeEnum.Success, "Success");
            BaseValidationContainer.AddMessage(MessageTypeEnum.Warning, "Warning");
            BaseValidationContainer.AddMessage(MessageTypeEnum.Informational, "Information");
    
            return View();
    
        }
    }
