    public class CustomController : Controller
    {
        HttpCookie mYcookie = this.Request.Cookies["trycookie"];
        HttpCookie cookieCounter = this.Request.Cookies["trycookie"];
        protected override void OnActionExecuted()
        {
            if (cookieCounter == null)
            {
                mYcookie = new HttpCookie("somenamehere");
            }
            else
            {
            // do something here //
            }
        }
    }
