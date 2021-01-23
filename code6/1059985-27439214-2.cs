    public static SqlParameter CreateParam(
        string paramName,
        object value,
        SqlDbType sqlDbType)
    {
        SqlParameter p = new SqlParameter(paramName, sqlDbType)
        {
            Value = value ?? DBNull.Value,
        };
        return p;
    }
