    public class PocoAccessor
    {
       public string Title {get; private set;}  
       internal static PocoAccessor ToPocoAccessor(Poco source)
       {
          return new PocoAccessor { Title = source.Title}
       }
    }
   
    public class Foo 
    {
       public PocoAccessor MyPoco {get; set;}
    }
