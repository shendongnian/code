    public static T ConvertFromDBVal<T>(object obj)
    {
        if (obj == null || Convert.IsDBNull(obj))
            return default(T);
        else
            return (T)obj;
    }
    public DataTable GetMetadata(string tableName)
    {
        // Again, connection open at this point
        OleDbCommand selectTable = new OleDbCommand("SELECT * FROM [" +
            tableName + "]", _oleConnection);
        OleDbDataReader oleReader = selectTable.ExecuteReader();
        
        DataTable schemaTable = oleReader.GetSchemaTable().Copy();
        schemaTable.Columns.Add("_maxCharLength", typeof(int));
        foreach (DataRow schemaRow in schemaTable.Rows)
        {
            OleDbCommand getMax = new OleDbCommand();
            getMax.Connection = _oleConnection;
            if (schemaRow.Field<Type>("DataType") == typeof(string))
                getMax.CommandText = "SELECT MAX(LEN(" +
                    schemaRow.Field<string>("ColumnName") + ")) FROM " +
                    tableName;
            else
                getMax.CommandText = "SELECT MAX(LEN(STR(" +
                    schemaRow.Field<string>("ColumnName") + "))) FROM " +
                    tableName;
            int maxCharLength = ConvertFromDBVal<int>(getMax.ExecuteScalar());
            schemaRow.SetField("_maxCharLength", maxCharLength);
            getMax.Dispose();
            getMax = null;
        }
        ...
        return schemaTable;
    }
