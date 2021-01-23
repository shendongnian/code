    public interface ICanRead
    {
        string Read();
    }
    public interface ICanWrite
    {
        void Write(string name);
    }
    public interface ICanReadAndWrite : ICanRead, ICanWrite {}
    class ConsoleReadWriter : ICanReadAndWrite
    {
        public string Read()
        {
            return Console.ReadLine();
        }
        public void Write(string name)
        {
            Console.WriteLine(name);
        }
    }
    public interface IReadWriterFactory
    {
        ICanReadAndWrite GetClass();
    }
    public class ConsoleReadWriterFactory : IReadWriterFactory
    {
        public ICanReadAndWrite GetClass()
        {
            return new ConsoleReadWriter();
        }
    }
