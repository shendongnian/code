    public class DataType1 : IReadable
    {
        public DataType1() { }
    
        public string Read() { return "dt1"; }
    }
    
    public class DataType2 : IReadable
    {
        public DataType2() { }
    
        public string Read() { return "dt2"; }
    }
    public interface IReadable
    {
        string Read();
    }
