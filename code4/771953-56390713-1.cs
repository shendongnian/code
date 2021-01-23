    public void SaveDataInTables(DataTable dataTable, string tablename)
    {
       if (dataTable.Rows.Count > 0)
       {
           using (SqlConnection con = new SqlConnection("Your_ConnectionString"))
           {
               using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
               {
                   sqlBulkCopy.DestinationTableName = tablename;
                   con.Open();
                   sqlBulkCopy.WriteToServer(dataTable);
                   con.Close();
                }
            }
        }
    }
