    public partial class BaseController : Controller
        {
            public SessionBox SessionBox;
    
            protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                SessionBox = new SessionBox(filterContext.HttpContext);
                base.OnActionExecuting(filterContext);
            }
    }
    
    
     public class SessionBox
        {
            private HttpContextBase context { get; set; }
    
            public SessionBox(HttpContextBase context)
            {
                this.context = context;
            }
    
            public bool ShowSuccessPopup
            {
                get
                {
                    if (context.Session["ShowSuccessPopup"] == null)
                    {
                        context.Session["ShowSuccessPopup"] = false;
                        return false;
                    }
                    else
                    {
                        var result = Convert.ToBoolean(context.Session["ShowSuccessPopup"].ToString());
                        return result;
                    }
                }
    
                set { context.Session["ShowSuccessPopup"] = value; }
    
            }
        }
