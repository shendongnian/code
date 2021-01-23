        /// <summary>
        /// This action filter will handle the errors which has http response code 500. 
        /// As Ajax is not handling this error.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        public sealed class HandleErrorAttribute : FilterAttribute, IExceptionFilter
        {
            private Type exceptionType = typeof(Exception);
    
            private const string DefaultView = "Error";
    
            private const string DefaultAjaxView = "_Error";
    
            public Type ExceptionType
            {
                get
                {
                    return this.exceptionType;
                }
    
                set
                {
                    if (value == null)
                    {
                        throw new ArgumentNullException("value");
                    }
    
                    this.exceptionType = value;
                }
            }
    
            public string View { get; set; }
    
            public string Master { get; set; }
    
            public void OnException(ExceptionContext filterContext)
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException("filterContext");
                }
    
                if (!filterContext.IsChildAction && (!filterContext.ExceptionHandled && filterContext.HttpContext.IsCustomErrorEnabled))
                {
                    Exception innerException = filterContext.Exception;
    
                    // adding the internal server error (500 status http code)
                    if ((new HttpException(null, innerException).GetHttpCode() == 500) && this.ExceptionType.IsInstanceOfType(innerException))
                    {
                        var controllerName = (string)filterContext.RouteData.Values["controller"];
                        var actionName = (string)filterContext.RouteData.Values["action"];
                        var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
    
                        // checking for Ajax request
                        if (filterContext.HttpContext.Request.IsAjaxRequest())
                        {
                            var result = new PartialViewResult
                            {
                                ViewName = string.IsNullOrEmpty(this.View) ? DefaultAjaxView : this.View,
                                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                                TempData = filterContext.Controller.TempData
                            };
                            filterContext.Result = result;
                        }
                        else
                        {
                            var result = this.CreateActionResult(filterContext, model);
                            filterContext.Result = result;
                        }
    
                        filterContext.ExceptionHandled = true;
                    }
                }
            }
    
            private ActionResult CreateActionResult(ExceptionContext filterContext, HandleErrorInfo model)
            {
                var result = new ViewResult
                {
                    ViewName = string.IsNullOrEmpty(this.View) ? DefaultView : this.View,
                    MasterName = this.Master,
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData,
                };
    
                result.TempData["Exception"] = filterContext.Exception;
    
                return result;
            }
        }
