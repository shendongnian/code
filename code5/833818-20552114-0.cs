    public class BaseClass
    {
        public virtual void MyMethod() 
        { 
            // Do some stuff...
        }
    }
    public class DerivedClass : BaseClass
    {
        public override void MyMethod()
        {
            // Do something new...
            
            // Do the stuff in BaseClass.MyMethod()
            base.MyMethod(); 
        }
    }
