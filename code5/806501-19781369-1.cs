    public class SuperCoolAuthorize : AuthorizationAttribute
    {
        public string Parameter1{get;set;}
        public string Parameter2{get;set;}
        public int Parameter3{get;set;}
        public string Parameter4{get;set;}
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // your custom behaviour
        }
    }
