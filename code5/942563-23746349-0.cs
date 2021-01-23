    public abstract class MyBaseController : Controller
    {
        protected override void OnActionExecuting(
    	ActionExecutingContext filterContext
            )
        {
            int maxtries = 5;
            while(maxtries > 0)
            {
                try
                {
                    return base.OnActionExecuting(filtercontext);
                }
                catch(DeadlockException dlex)
                {
                    maxtries--;
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
            throw new Exception("Persistent DB locking - max retries reached.");
        }
    }
