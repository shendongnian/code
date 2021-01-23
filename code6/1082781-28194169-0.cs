    public class StationProperty<T> : StationProperty
    {
        public StationProperty()
        {
        }
        public StationProperty(int id, T val, string desc = "")
        {
            Id = id;
            Desc = desc;
            Value = val;
        }
        public int Id { get; set; }
        public string Desc { get; set; }
        public T Value { get; set; }
        object StationProperty.Value
        {
            get { return Value; }
        }
        public Type ValueType
        {
            get { return typeof (T); }
        }
    }
    public interface StationProperty
    {
        int Id { get; set; }
        string Desc { get; set; }
        object Value { get; }
        Type ValueType { get; }
    }
    
