    public class MyClass
    {
        public ILogger Logger { get; private set; }
        public MyClass(ILogger logger)
        {
            this.Logger = logger;
        }
    }
