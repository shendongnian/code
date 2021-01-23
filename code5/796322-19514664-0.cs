    public class Holder<T> where T : IObject 
    {
      public T SomeField;
    }
    ...
    var holder = new Holder<IObjectSubType2>();
    Holder<IObject> dummy = holder; //assuming that this works
    dummy.SomeField = new IObjectSubType1(); //violates type safety
    IObjectSubType2 converted = holder.SomeField;
