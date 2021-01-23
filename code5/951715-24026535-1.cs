        [CustomAuthFilter]
        public class ValuesController : ApiController
        {
            public string Name { get; set; }
            public string GetAll()
            {
                return this.Name;
            }
        }
        public class CustomAuthFilter : AuthorizationFilterAttribute
        {
            public override void OnAuthorization(HttpActionContext actionContext)
            {
                ValuesController valuesCntlr = actionContext.ControllerContext.Controller as ValuesController;
                if (valuesCntlr != null)
                {
                    valuesCntlr.Name = "<your value from header>";
                }
            }
        }
