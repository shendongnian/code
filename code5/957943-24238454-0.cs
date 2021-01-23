    public override void OnActionExecuting(ActionExecutingContext filterContext)
     {
         var queryStringQ =  Server.UrlDecode(filterContext.HttpContext.Request.QueryString["q"]);
     if (!string.IsNullOrEmpty(queryStringQ))
            {
                // Decrypt query string value
                var queryParams = DecryptionMethod(queryStringQ);
            }
     }
