    public class MyMiddleware
    {
      RequestDelegate _next;
    
      public MyMiddleware(RequestDelegate next)
      {
        _next = next;
      }
    
      public async Task Invoke(HttpContext context, IMyService myService)
      {
        --> Now working. MyService is registered on context.RequestServices 
      }
    }
