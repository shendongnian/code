    public abstract class BaseClass
    {
       protected BaseField BaseField{get;set;};
       public void SomeMethod()
       {
        baseField.DoSomething()
       }
    }
    public class ChildClass : BaseClass
    {
          public ChildClass()
          {
             this.BaseField = new ExtendedBaseField();
          }
    }
