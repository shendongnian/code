     [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class ExportModelStateToTempDataAttribute : ModelStateTempDataTransfer
        {
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                // Only copy when ModelState is invalid and we're performing a Redirect (i.e. PRG)
                if (!filterContext.Controller.ViewData.ModelState.IsValid &&
                    (filterContext.Result is RedirectResult || filterContext.Result is RedirectToRouteResult)) 
                {
                    ExportModelStateToTempData(filterContext);
                }
                
                base.OnActionExecuted(filterContext);
            }
        }
     /// <summary>
        /// An Action Filter for importing ModelState from TempData.
        /// You need to decorate your GET actions with this when using the <see cref="ValidateModelStateAttribute"/>.
        /// </summary>
        /// <remarks>
        /// Useful when following the PRG (Post, Redirect, Get) pattern.
        /// </remarks>
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class ImportModelStateFromTempDataAttribute : ModelStateTempDataTransfer
        {
            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                // Only copy from TempData if we are rendering a View/Partial
                if (filterContext.Result is ViewResult)
                {
                    ImportModelStateFromTempData(filterContext);
                }
                else 
                {
                    // remove it
                    RemoveModelStateFromTempData(filterContext);
                }
    
                base.OnActionExecuted(filterContext);
            }
        }
    
     [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public abstract class ModelStateTempDataTransfer : ActionFilterAttribute
        {
            protected static readonly string Key = typeof(ModelStateTempDataTransfer).FullName;
    
            /// <summary>
            /// Exports the current ModelState to TempData (available on the next request).
            /// </summary>       
            protected static void ExportModelStateToTempData(ControllerContext context)
            {
                context.Controller.TempData[Key] = context.Controller.ViewData.ModelState;
            }
    
            /// <summary>
            /// Populates the current ModelState with the values in TempData
            /// </summary>
            protected static void ImportModelStateFromTempData(ControllerContext context)
            {
                var prevModelState = context.Controller.TempData[Key] as ModelStateDictionary;
                context.Controller.ViewData.ModelState.Merge(prevModelState);
            }
    
            /// <summary>
            /// Removes ModelState from TempData
            /// </summary>
            protected static void RemoveModelStateFromTempData(ControllerContext context)
            {
                context.Controller.TempData[Key] = null;
            }
        }
    
      /// <summary>
        /// An ActionFilter for automatically validating ModelState before a controller action is executed.
        /// Performs a Redirect if ModelState is invalid. Assumes the <see cref="ImportModelStateFromTempDataAttribute"/> is used on the GET action.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class ValidateModelStateAttribute : ModelStateTempDataTransfer
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (!filterContext.Controller.ViewData.ModelState.IsValid)
                {
                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        ProcessAjax(filterContext);
                    }
                    else
                    {
                        ProcessNormal(filterContext);
                    }
                }
                
                base.OnActionExecuting(filterContext);
            }
    
            protected virtual void ProcessNormal(ActionExecutingContext filterContext)
            {
                // Export ModelState to TempData so it's available on next request
                ExportModelStateToTempData(filterContext);
    
                // redirect back to GET action
                filterContext.Result = new RedirectToRouteResult(filterContext.RouteData.Values);
            }
    
            protected virtual void ProcessAjax(ActionExecutingContext filterContext)
            {
                var errors = filterContext.Controller.ViewData.ModelState.ToSerializableDictionary();
                var json = new JavaScriptSerializer().Serialize(errors);
    
                // send 400 status code (Bad Request)
                filterContext.Result = new HttpStatusCodeResult((int)HttpStatusCode.BadRequest, json);
            }
        }
