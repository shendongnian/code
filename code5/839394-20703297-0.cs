    public class MyModel 
    {
         public IHtmlString Property { get; private set; }
         public MyModel(string property)
         {
              Property = new MvcHtmlString(property);
         }
    }
