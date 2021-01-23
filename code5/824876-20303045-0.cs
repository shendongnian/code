    public interface ICookieProvider
    {
        HttpCookieCollection GetCookies();
    }
    public class RealCookieProvider : ICookieProvider
    {
        public HttpCookieCollection GetCookies() 
        {
            return HttpContext.Current.Request.Cookies;
        }
    }
