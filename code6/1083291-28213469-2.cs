    public interface IStationProperty : IComparable<IStationProperty>
    {
        int Id { get; set; }
        string Desc { get; set; }
        object Value { get; }
        Type ValueType { get; }
    }
    [Serializable]
    public class StationProp<T> : IStationProperty where T : IComparable
    {
        public StationProp()
        {
        }
        public StationProp(int id, T val, string desc = "")
        {
            Id = id;
            Desc = desc;
            Value = val;
        }
        public int Id { get; set; }
        public string Desc { get; set; }
        public T Value { get; set; }
        object IStationProperty.Value
        {
            get { return Value; }
        }
        public Type ValueType
        {
            get { return typeof(T); }
        }
        public int CompareTo(IStationProperty other)
        {
            if (other.ValueType == typeof(string))
            {
                return Value.CompareTo((string)other.Value);
            }
            else if (other.ValueType == typeof(int))
            {
                return Value.CompareTo((int)other.Value);
            }
            else if (other.ValueType == typeof(double))
            {
                return Value.CompareTo((double)other.Value);
            }
            throw new NotSupportedException();
        }
    }
