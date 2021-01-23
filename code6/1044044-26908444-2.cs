    public class ApiAuthorizeAttribute : AuthorizeAttribute{
       protected override bool IsAuthorized(HttpActionContext actionContext){
          // Make your logic to check is user authorized
       }
        public override void OnAuthorization(HttpActionContext actionContext){
          // Make your authorization logic
        }
    }
