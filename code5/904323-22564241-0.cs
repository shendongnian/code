    public class ValuesController : ApiController
    {
        [CustomActionFilter]
        public string GetAll(string username)
        {
            return username;
        }
    }
    
    public class CustomActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            object obj = null;
            if(actionContext.ActionArguments.TryGetValue("username", out obj))
            {
                string originalUserName = (string)obj;
    
                actionContext.ActionArguments["username"] = "modified-username";
            }
        }
    }
