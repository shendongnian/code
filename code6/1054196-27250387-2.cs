    private bool SpalteExistiert(FbDataReader Reader, string MyColumnName) 
    {
        return Reader.GetSchemaTable()
           .Rows
           .OfType<DataRow>()
           .Any(row => string.Equals(row.Field<string>("ColumnName"), MyColumnName, StringComparison.InvariantCultureIgnoreCase)); 
    }
