    public interface ISomeInterface
    {
       int SomeMethod(int x);
       string DerivedType {get;}
    }
    public DerivedClass : ISomeInterface
    {
       public int DomeMethod (int x) {...};
       public string DerivedType
       {
          get {return "derivedType"; }
       }
    }
