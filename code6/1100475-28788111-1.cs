    public abstract class BaseClass<T>
        where T: BaseField
    {
        protected BaseClass(T baseField)
        {
             this.BaseField = baseField;
        }
        protected T BaseField{get; private set;};
       public void SomeMethod()
       {
        BaseField.DoSomething()
       }
    }
    public class ChildClass : BaseClass<ExtendedBaseField>
    {
          public ChildClass() : base(new ExtendedBaseField())
          {
             
          }
    }
