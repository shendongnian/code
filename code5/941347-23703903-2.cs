    abstract class SuperClass
    {
        public abstract string MethodOne();
    }
    class ClassOne : SuperClass
    {
        public override string MethodOne()
        {
            return ("ClassOne");
        }
    }
