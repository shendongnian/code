    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)] 
    public class AddGuidAttribute : FilterAttribute, IActionFilter 
    { 
        public void OnActionExecuting(ActionExecutingContext filterContext) 
        {
            var request = filterContext.RequestContext.HttpContext.Request;
            if (request["guid"] == null)
            {
                var builder = new UriBuilder(request.RawUrl);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["guid"] = Guid.NewGuid();
                builder.Query = query.ToString();
                filterContext.Result = new RedirectResult(builder.ToString());
            }
        } 
    }
    
