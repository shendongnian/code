    abstract class A 
    {    
        public abstract void F();
    }
    class B: A 
    {   
        public override void F() 
        {
            base.F(); // Error, base.F is abstract
        }
    }
