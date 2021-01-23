     public class MyMiddleware : OwinMiddleware
     {
        public MyMiddleware(OwinMiddleware next)
            : base(next) { }
        public override Task Invoke(IOwinContext context)
        {
            //Analyze the request. 
            //find the client id
            //RedirectToClientSpecificUrl?
        }
     }
