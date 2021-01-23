    public class MyClass
    {
        public MyClass()
        {
        }
        public void Foo()
        {
            //todo do stuff
        }
    }
    public class BetterMyClass : MyClass
    {
        private readonly string _filePath;
        public BetterMyClass(string filePath)
        {
            _filePath = filePath;
        }
        public void Export()
        {
            var fi = new FileInfo(_filePath);
        }
    }
