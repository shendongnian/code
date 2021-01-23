    public class XFrameOptionAllowAll : ActionFilterAttribute
    {
        #region <Methods>
    
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Headers.Remove("X-Frame-Options");
            filterContext.HttpContext.Response.AddHeader("X-Frame-Options", "AllowAll");
    
            base.OnResultExecuted(filterContext);
        } 
    
        #endregion
    }
