    public class MainController : Controller
    {
    #region Member Variables
    
       private IAuthenticationBO authentication = null;
    
    #endregion
    
       public MainController(IAuthenticationBO authentication)
       {
    	   this.authentication = authentication;
       }
    }
