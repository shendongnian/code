    public class BaseClass
    {
        protected BaseClass(int p)
        {
        }
    }
    public class SubClass : BaseClass
    {
        public SubClass()
            : base(int.MinValue)
        {
        }
        public SubClass(int p)
            : base(p)
        {
        }
    }
