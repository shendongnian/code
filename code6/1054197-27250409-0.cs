    private bool SpalteExistiert(FbDataReader Reader, string MyColumnName) 
    {
        return Reader.GetSchemaTable()
           .Rows
           .OfType<DataRow>()
           .Any(row => row.Table.Columns.Contains(MyColumnName)); 
    }
