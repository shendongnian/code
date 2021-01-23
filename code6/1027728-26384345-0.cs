    public static void ExcelToSqlServerBulkCopy ()
    {
      // Connection String to Excel Workbook
      // Jet4
      string excelConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=AgentList.xls; Extended Properties=""Excel 8.0;HDR=YES;""";
      // Ace Ole db 12
      string excelAceOleDb12ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AgentList.xls;Extended Properties=""Excel 8.0;HDR=YES;""";
      
      // Create Connection to Excel Workbook
      using (OleDbConnection connection = new OleDbConnection(excelAceOleDb12ConnectionString))
      {
        OleDbCommand command = new OleDbCommand("Select [Merchant_Name],[Store_Name],[Store_Address],[City] FROM [AgentList$]", connection);
        // open excel
        connection.Open ();        
        // Create DbDataReader to Data Worksheet
        using (DbDataReader dr = command.ExecuteReader ())
        {
          // SQL Server Connection String
          string sqlConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StackOverflow;Integrated Security=True";
          // Bulk Copy to SQL Server
          using (SqlBulkCopy bulkCopy = new SqlBulkCopy (sqlConnectionString))
          {
            bulkCopy.DestinationTableName = "Q26382169";
            bulkCopy.WriteToServer (dr);
          }
        }
      }
    }
