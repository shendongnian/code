    public class MyClass
    {
        // Coupled onto the the interface. Dependency can be mocked, and substituted
        private readonly IMyInterface _instance;
        public MyClass(IMyInterface instance)
        {
           _instance = instance;
        }
        ...
