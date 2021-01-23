    public class SomeHandler : IHttpHandler
    {
      public void ProcessRequest(HttpContext context)
      {
        var request = context.Request;
        NameValueCollection formVariables = request.Form;
        //do something to process the collection
      }
    }
