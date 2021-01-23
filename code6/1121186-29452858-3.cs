    [AttributeUsage(AttributeTargets.Interface)]
    public class DataTypeAttribute : Attribute
    {
        public DataTypeAttribute(DataTypes dataType)
        {
            DataType = dataType;
        }
        public DataTypes DataType { get; private set; }
    }
