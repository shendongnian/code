    public class MyActualClass
    {
      protected static readonly string _url = "SomeURL";
      //... other code
    }
    public class MyActualClassStub : MyActualClasss
    {
      public string GetUrlValue()
      {
        return _url;
      }
    }
