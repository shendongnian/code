    public static SqlBoolean check_smallint(SqlString input)
    {
        if (input.IsNull)
            return true;
        if (input.Value.Trim() == String.Empty)
            return true;
    
        short value;
        return Int16.TryParse(input.Value, out value);
    }
