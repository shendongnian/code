    public class ParentController : Controller
    {
        public string GetUrl()
        {
            return ConfigurationManager.AppSettings["AppUrl"];
        }
    }
