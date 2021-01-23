    public interface IBoundDataColumn
    {
        public Type DataType {get;}
    }
    
    public class DateTimeColumn : IBoundDataColumn
    {
        public string Name {get;set;}
        public DateTime Value {get;set;}
        public Type DataType { get { return typeof(DateTime); } }
    }
