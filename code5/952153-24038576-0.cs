    public class AuthenticationFilter : ActionFilterAttribute
    {
        public KhbyraAuthenticationFilter()
        {
        }
    
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            using(var repo = new MyDbRepository(new MyDbContext()))
            {
                //Login code accessing database by repo object.
            }
        }
     }
