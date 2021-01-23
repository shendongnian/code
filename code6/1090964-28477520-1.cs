    public abstract class BaseAbstractController : Controller
    {
        public BaseAbstractController()
        {
            if (System.Web.HttpContext.Current.Request.HttpMethod.ToString() == "GET")
            {
                System.Web.HttpContext.Current.Session["testsession"] = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            }
        }
    }
