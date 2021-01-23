    public class A
    {
        public virtual A Method()
        {
            //Code returning an A
        }
    }
    public class B : A 
    {
        public override A Method() {
            //Code returning a B
        }
    }
