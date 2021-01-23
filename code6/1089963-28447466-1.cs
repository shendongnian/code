    public interface IDataType
    {
        string Read();
    }
    public class DataType1 : IDataType
    {
        public DataType1() { }
        public string Read() { return "dt1"; }
    }
    public class DataType2 : IDataType
    {
        public DataType2() { }
        public string Read() { return "dt2"; }
    }
    public class Logger<T> where T : IDataType, new()
    {
        IDataType dataType { get; set; }
        public Logger() {
            dataType = new T();
        }
        public string Read()
        {
            return dataType.Read();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test1 = new Logger<DataType1>();
            test1.Read(); // I want this to equal "dt1";
            var test2 = new Logger<DataType2>();
            test2.Read(); // I want this to equal "dt2";
        }
    }
