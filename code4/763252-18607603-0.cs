    public class CustomController : Controller
    {
        protected override void OnActionExecuted()
        {
            HttpCookie myCookie = this.Request.Cookies["trycookie"];
            HttpCookie cookieCounter = this.Request.Cookies["cookieCounter"];
    
            if (cookieCounter != null)
            {
                // do something here //
            }
        }
    }
