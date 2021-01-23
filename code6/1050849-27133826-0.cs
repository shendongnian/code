    public class MyService
    {
        public ServiceResult SomeMethod()
        {
            ...
            var value = GetVariable(System.Web.HttpContext.Current, "some var name");
            ...
        }
        protected virtual string GetVariable(HttpContext fromContext, string name)
        {
            return fromContext.Request.ServerVariables[name];
        }
        
    }
