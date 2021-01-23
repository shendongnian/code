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
    
    public class Logger
    {
        IDataType dataType { get; set; }
    
        public Logger(IDataType dt) {
            dataType = dt;
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
            var dt1 = new DataType1();
            var test1 = new Logger(dt1);
            test1.Read(); // I want this to equal "dt1";
    
            var dt2 = new DataType2();
            var test2 = new Logger(dt2);
            test2.Read(); // I want this to equal "dt2";
        }
    }
