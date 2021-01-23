    class Derived1 : Base
    {
       public override void DoSth()
       {
       }
    }
    abstract class Derived2 : Derived1
    {
       public virtual new void DoSth()
       {
       }
    
    }
