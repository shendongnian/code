     public static string GetParameterlessPath(ActionExecutingContext filterContext)
        {
            return GetParameterlessPath(filterContext.ActionDescriptor.ActionName,
                VirtualPathUtility.ToAppRelative(filterContext.HttpContext.Request.Path));
        }
        public static string GetParameterlessPath(string action, string relativeUrl)
        {
            return  relativeUrl.Contains(action) 
                 ? relativeUrl.Substring(0, relativeUrl.LastIndexOf(action))+action 
                 : relativeUrl;
        }
