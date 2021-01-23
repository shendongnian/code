     public class CheckSessions: ActionFilterAttribute
     { 
       public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
          if (HttpContext.Current.Session["LoginSession"] == null && 
           HttpContext.Current.Session["LoginSession"] == null)
          {
               if(HttpContext.Current.Request.IsAjaxRequest())
                {
                 HttpContext.Current.Response.StatusCode="401"; //Session Expired
                }
               else
                {
                 HttpContext.Current.Response.Redirect("/Account/Login");
                }
               
           }
        }
      }
