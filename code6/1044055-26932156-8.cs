    public sealed class LogAttribute : ActionFilterAttribute
        {
            private ILog _log;
            
            // This is the magic part - Unity reads this attribute and sets injects the related property. This means no parameters are required in the constructor.
            [Microsoft.Practices.Unity.Dependency]
            public ILog Log
            { 
                get
                {
                    return this._log;
                } 
                set
                {
                    this._log = value;
                }  
            }
        
            public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
            {
                this._log.Info("Exited " + actionContext.Request.Method);
            }
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                this._log.Info("Entering" + actionContext.Request.Method);
            }
        }    
    
