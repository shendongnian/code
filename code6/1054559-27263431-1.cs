    public override void OnActionExecuting(HttpActionContext actionContext)
                
       {
           var test = (actionContext.Request.Content as ObjectContent).Value.ToString();
           // your logging code here
       }
