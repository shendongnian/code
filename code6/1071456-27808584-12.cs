    public bool GetBoolean(DbDataRecord rec, string fieldName)
    {
        int pos = rec.GetOrdinal(fieldName);
        if(rec.IsDBNull(pos))
            return false; // ??
            
        object result = rec.GetValue(pos);   
        return Convert.ToBoolean(result);
    }
