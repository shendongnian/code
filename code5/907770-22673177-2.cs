    public class AccountController: Controller {
    
        public class ActionResult Index(object id, string version)
        {
           if (string.Equals(version, "v2", StringComparison.OrdinalIgnoreCase))
           {
              return Version2Code();
           }
           return Version1Code();
        }
    }
