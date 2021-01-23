    public static string GetStringWithNullCheck(this IDataReader reader, int index)
    {
        if(reader.IsDBNull(index))
            return null;
        return reader.GetString(index); //If we called this on a record that is null we get a InvalidCastException.
    }
