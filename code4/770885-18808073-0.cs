    abstract class Parent : IValidatable
    {
        public abstract bool IsValid();
        abstract protected void _run();
        public Parent()
        {
        }
        public void run()
        {
            _run();
            if (!IsValid())
                //throw
        }
    }
    class Child : Parent
    {
        protected object value1;
        protected object value2;
        // not required..
        protected object value3;
        protected override void _run()
        {
            // This must set all 'required' properties' values, otherwise the Parent should throw.
            value1 = "some value";
            value2 = "some other value";
        }
        public override bool IsValid()
        {
            return value1 != null && value2 != null;
        }
    }
    public interface IValidatable
    {
        bool IsValid();
    }
