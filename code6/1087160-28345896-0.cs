    public class DemoAuthorizeAttribute : AuthorizeAttribute
        {     
    
            public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext){
                if (Authorize(actionContext)){
                    return;
                }
                HandleUnauthorizedRequest(actionContext);
            }
    
            protected override void HandleUnauthorizedRequest(System.Web.Http.Controllers.HttpActionContext actionContext){
                var challengeMessage = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized;
    //Adding your code here
     var id = new ClaimsIdentity();
     id.AddClaim(new Claim("Whatever", "is possible"));
     context.Authentication.User.AddIdentity(id);
                challengeMessage.Headers.Add("WWW-Authenticate", "Basic");
                throw new HttpResponseException(challengeMessage);
            }
    
            private bool Authorize(System.Web.Http.Controllers.HttpActionContext actionContext){
                try{
                    var someCode = (from h in actionContext.Request.Headers where h.Key == "demo" select h.Value.First()).FirstOrDefault();
                     // or check for the claims identity property.
                    return someCode == "myCode";
                }
                catch (Exception){
                    return false;
                }
            }
        }
