    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(typeof(MyMiddleware)); 
        }
    }
	
	public class MyMiddleware : OwinMiddleware
    {
        public MyMiddleware(OwinMiddleware next) : base(next) { }
        public override async Task Invoke(IOwinContext context)
        {
            await Next.Invoke(context);
            if(context.Response.StatusCode== 404)
            {
                context.Response.StatusCode = 403;
                context.Response.ReasonPhrase = "Blah";
            }
        }
    }
