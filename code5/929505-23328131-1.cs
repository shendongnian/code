    public class LazyClass
    {
     private Lazy<MyType> myType = new Lazy<MyType>(() => new MyType());
    
     public MyType MyTypeProperty
     {
      get { return this.myType.Value; }
     }
    }
