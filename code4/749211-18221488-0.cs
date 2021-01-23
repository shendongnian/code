    public static SqlParameter Create(string name, SqlDbType type, object value)
    {
        var p = new SqlParameter();
        p.Name = name;
        p.Type = type;
        // If type is a fixed-length type, maybe set the correct string length here
        if (value == null)
        {
            p.Value = DBNull.Value;
        }
        else
        {
            p.Value = value;
        }
        return p;
    }
