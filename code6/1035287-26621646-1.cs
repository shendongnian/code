    public class BaseClass
    {
       public virtual void MyMethod()
       {
    
       }
    }
    
    public class DerivedClass : BaseClass
    {
       public override void MyMethod()
       {
          // do soothing different
          base.MyMethod()
       }
    }
