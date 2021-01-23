    abstract class A 
    {
        public abstract object GetValue();
    }
    class B : class A
    {
        public int val {get;private set;}
        public override object GetValue()
        {
            return val;
        }
    }
