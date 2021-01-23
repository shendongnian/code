    public class CustomExceptionMiddleware : OwinMiddleware
    {
       public CustomExceptionMiddleware(OwinMiddleware next) : base(next)
       {}
 
       public override async Task Invoke(IOwinContext context)
       {
          try
          {
              await Next.Invoke(context);
          }
          catch(Exception ex)
          {
              // Custom stuff here
          }
       }
     }
