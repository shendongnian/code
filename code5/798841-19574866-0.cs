    public interface IExportInterface
    {
        void Export();
    }
    public interface INoExportInterface
    {
        //Other methods
    }
    internal class MyClass : IExportInterface, INoExportInterface
    {
        private readonly string _filePath;
        public MyClass()
        {
        }
        public MyClass(string filePath)
        {
            _filePath = filePath;
        }
        public void Export()
        {
            var fi = new FileInfo(_filePath);
        }
    }
    public class MyClassFactory
    {
        public static IExportInterface GetMyClass(string filePath)
        {
            return new MyClass(filePath);
        }
        public static INoExportInterface GetMyClass()
        {
            return new MyClass();
        }
    }
