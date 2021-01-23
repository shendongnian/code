    public class MyMiddleWare : OwinMiddleware
    {
      public MyMiddleWare(OwinMiddleware next)
        : base(next) {}
    
      public override Task Invoke(IOwinContext context)
      {
        context.Response.Write("Hello world!!");
        return Next.Invoke(context);
      }
    }
