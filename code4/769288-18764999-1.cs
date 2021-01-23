    public static Type getJavaDataType(DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Boolean:
                return typeof(bool);
            case DataType.Date:
                return typeof(DateTime);
            case DataType.Integer:
                return typeof(int);
            case DataType.String:
                return typeof(string);
            default:
                return null;
        }
    }
