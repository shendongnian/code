        public class testAttribute : AuthorizeAttribute
        {
           protected override bool AuthorizeCore(HttpContextBase httpContext)
           {
            HttpCookie cookie = httpContext.Request.Cookies.Get("cookieName");
            if(Int32.TryParse(cookie.Value) == 5)
            {
            httpContext.Response.StatusCode = 401;
            httpContext.Response.End();
            return false;
            }
            else
            return true;
           }
        }
