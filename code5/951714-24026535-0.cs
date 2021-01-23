        [CustomAuthFilter]
        public class ValuesController : ApiController
        {
            public string Name
            {
                get
                {
                    return Request.Properties["Name"].ToString();
                }
            }
            public string GetAll()
            {
                return this.Name;
            }
        }
        public class CustomAuthFilter : AuthorizationFilterAttribute
        {
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                actionContext.Request.Properties["Name"] = "<your value from header>";
            }
        }
