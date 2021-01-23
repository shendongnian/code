    public class MyClass
    {
        private readonly IMyInterface _instance;
        public MyClass(IMyInterface instance)
        {
           _instance = instance;
        }
        ...
