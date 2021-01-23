    public Dictionary<string, List<object>> GetTableInformation(string tableName, FinkonaDatabaseType type)
    {
       var sqlText = "SELECT * from " + tableName;
       DataTable dt = new DataTable();
    
       // Use DataTables to extract the whole table in one hit
       using(SqlDataAdapter da = new SqlDataAdapter(sqlText, optimumEntities.Database.ConnectionString)
       {
          da.Fill(dt);   
       }
    
       var tableData = new Dictionary<string, List<object>>();
    
       // Go through all columns, retrieving their names and populating the rows
       foreach(DataColumn dc in dt.Columns)
       {
          string columnName = dc.Name;
          rowData = new List<object>();
          tableData.Add(columnName, rowData);
       
          foreach(DataRow dr in dt.Rows)
          {
             rowData.Add(dr[columnName]);   
          }
       }
    
       return tableData;
    }
