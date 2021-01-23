    public class MyClass
    {
       private readonly IHttpContext _httpContext;
       MyClass(IHttpContext httpContext)
       {
           _httpContext = httpContext;
       }
       public void Blaat()
       {
            _httpContext.DoYourThingsWithTheHttpContext();
        }
    }
