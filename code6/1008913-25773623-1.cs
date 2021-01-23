    public static MvcHtmlString ActionLinkAuthorized(this HtmlHelper htmlHelper, string roles, other arguments)
    {
       //assuming that roles are passed as coma separated strings
       var rolesList = roles.Split(",",roles);
       bool shouldShow = false;
       foreach(var role in rolesList )
       {
           if (HttpContext.User.IsInRole(role))
           {
               shouldShow = true;
               break;
           }               
       }
       if(shouldShow)
       {
           //return your extension representation 
       }
       else
       {
           //fallback 
       }
    }
