    class Program
    {
        static void Main(string[] args)
        {
            ReadWriter myReadWriter = new ReadWriter(new ConsoleReaderWriterFactory());
            string test = myReadWriter.Read();
            myReadWriter.Write("this is abstract factory power");
        }
    }
    public class ConsoleWriter : ICanWrite
    {
        public void Write(string name)
        {
            Console.WriteLine(name);
        }
    }
    public class ConsoleReader : ICanRead
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
    public interface ICanWrite
    {
        void Write(string name);
    }
    public interface ICanReadAndWrite : ICanRead, ICanWrite { }
    public interface ICanRead
    {
        string Read();
    }
    public class ReadWriter : ICanReadAndWrite
    {
        private ICanRead reader;
        private ICanWrite writer;
        public string Read()
        {
            return reader.Read();
        }
        public void Write(string name)
        {
            writer.Write(name);
        }
        public ReadWriter(IReaderWriterFactory factory)
        {
            reader = factory.CreateReader();
            writer = factory.CreateWriter();
        }
    }
    public interface IReaderWriterFactory
    {
        ICanRead CreateReader();
        ICanWrite CreateWriter();
    }
    public class ConsoleReaderWriterFactory : IReaderWriterFactory
    {
        public ICanRead CreateReader()
        {
            return new ConsoleReader();
        }
        public ICanWrite CreateWriter()
        {
            return new ConsoleWriter();
        }
    }
