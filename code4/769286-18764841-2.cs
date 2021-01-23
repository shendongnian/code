    public enum DataType
    {
        Boolean,
        String,
        Integer
    }
    public static class DataTypeExtensions
    {
        public static Type GetCsharpDataType(this DataType dataType)
        {
            switch(dataType)
            {
                case DataType.Boolen:
                    return typeof(bool);
                case DataType.String:
                    return typeof(string);
                default:
                    throw new ArgumentOutOfRangeException("dataType");
            }
        }
    }
