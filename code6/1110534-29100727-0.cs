     public override void OnException(HttpActionExecutedContext context)
                    {
                        var log= (ILog)context.ActionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(ILog));    
                    }
         
