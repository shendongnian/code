    public class Foo : IFoo
    {
       public string Bar()
       {
          using (var str = new StreamReader(HttpContext.Current.Request.InputStream))
          {
              string inputData = str.ReadToEnd();
              return inputData;
          }
       }
    }
