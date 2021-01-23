    public class DataEntry : Dictionary<string, object>
    {
        public DataEntry(IDictionary<string, object> entry)
            : base(entry)
        {
        }
    }
    
    public class DynamicDataEntry : DynamicObject, IDictionary<string, object>
    {
        // ...
