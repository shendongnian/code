    public static DateTime? GetNullableDateTime(this DbDataReader reader,
                                                string column)
    {
        object value = reader[column];
        return value == DBNull.Value ? (DateTime?) null : (DateTime) value;
    }
