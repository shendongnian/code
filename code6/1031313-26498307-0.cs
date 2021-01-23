    public static string FixString(object data)
    {
        return null;
    }
    static void Main(string[] args)
    {
        DataRow row = null;
        SqlParameter param = getSqlParameter(row, "Address", FixString);
    }
    private static SqlParameter getSqlParameter<T>(T item, string columnName, Func<object, object> method) where T : DataRow
    {
        return new SqlParameter(columnName, method(item[columnName]));
    }
