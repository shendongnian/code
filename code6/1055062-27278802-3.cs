    public class BaseClass
    {
        public BaseClass(string build)
        {
            Build = build;
        }
        public string Build { get; private set; }
    }
    public class SubClass : BaseClass
    {
        public SubClass()
          : base("Hello")  // Calls the base class' constructor with "Hello"
        {
        }
    }
