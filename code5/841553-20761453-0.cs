    function static void InsertDataIntoSQLServerUsingSQLBulkCopy(DataTable bulkData)
    {
        using(SqlConnection dbConnection = new SqlConnection("Data Source=ProductHost;Initial     Catalog=yourDB;Integrated Security=SSPI;"))
        {
             dbConnection.Open();
             using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
             {
                s.DestinationTableName = "Your table name";
                foreach (var column in bulkData.Columns)
                s.ColumnMappings.Add(column.ToString(), column.ToString());
                s.WriteToServer(bulkData);
             }
        }
    }
