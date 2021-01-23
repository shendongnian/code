    private bool SpalteExistiert(FbDataReader Reader, string MyColumnName) 
    {
        return Reader.GetSchemaTable()
           .Rows
           .OfType<DataRow>()
           .Any(row => string.Equals((string)row["ColumnName"], MyColumnName, StringComparison.InvariantCultureIgnoreCase)); 
    }
