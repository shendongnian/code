    public abstract class Base<DerivedType, OtherType> 
          where DerivedType : Base<DerivedType, OtherType>
    {
        protected abstract OtherType Factory(DerivedType d);
    
        public bool TryCreate(out OtherType o)
        {
           o = Factory ((DerivedType)this);
           return true;
        }
     }
    public  class MyClass : Base<MyClass, string>
    {
       protected override string Factory (MyClass d)
       {
          return d.GetType ().Name;
       }
    }
