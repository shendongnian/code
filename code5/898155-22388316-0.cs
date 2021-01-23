    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class UploadActionAttribute : ActionFilterAttribute
    {
        public UploadActionAttribute(double maxMb = 4d)
        {
            MaxMb = maxMb;
        }
    
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (ConvertBytesToMegabytes(filterContext.HttpContext.Request.ContentLength) > MaxMb)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult() { Data = new { Success = false, MaxContentLengthExceeded = true } };
                }
                else
                    filterContext.Controller.ViewData.ModelState.AddModelError("", string.Format(CSRess.MaxRequestLengh, MaxMb));
            }
            base.OnActionExecuting(filterContext);
        }
    
        private double MaxMb { get; set; }
        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
