    public static SqlParameter Create(string name, SqlDbType type, object value)
    {
        var p = new SqlParameter();
        p.ParameterName = name;
        p.SqlDbType = type;
        // If type is a fixed-length type, maybe set the correct string length here
        if (value == null)
        {
            p.SqlValue = DBNull.Value;
        }
        else
        {
            p.SqlValue = value;
        }
        return p;
    }
