      DataSet myDataSet= new DataSet();
      using (OracleConnection conn = new OracleConnection(connectionString))
       {
         using (OracleCommand cmd = new OracleCommand())
           {
    	cmd.BindByName = true;
    
            #region SQL Core
            StringBuilder sql = new StringBuilder();
            sql.Append(" <Your SQL Here> ");
            #endregion
    
            #region - ADD SQLParameter
             // use Parameters to avoid SQL Injection like @param1
             sql.Append(" AND (columnname = @param1 ");
             OracleParameter param1 = new OracleParameter("@param1", OracleDbType.Varchar2); 
                             param1.Value = yourValue;
    
             cmd.Parameters.Add(param1);
            #endregion
    
            cmd.CommandText = sql.ToString();
            cmd.Connection = conn;
                        
            try
              {
                 conn.Open();
                 try
                 {
                   OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                   adapter.Fill(myDataSet, "myDataSetName");
                 }
                 catch (Exception myex)
                 {
                   //Handle General Exception
                    Console.Write(myex);
                 }
              }
              Catch (OracleException myex)
              {
                //Handle Oracle Exception
                  Console.Write(myex);
              }
           }
    //Now you have a populated Data Set, you can loop over it extracting values.
    //This acts like an offline record set
    //Or you can Bind MyDataSet to a GridView to see the data in your offline table.
    
       //Output Result set in expected XML format and return
       DataTable dataTable = myDataSet.Tables[0];
    
       if (dataTable.Rows.Count > 0)
         {
         for (int i = 0; i < dataTable.Rows.Count; i++)
          {
           DataRow dataRow = dataTable.Rows[i];
           for (int x = 0; x < dataTable.Columns.Count; x++)
           {
           //dataTable.Rows[i].Table.Columns[x].ColumnName.ToString()
           if (dataTable.Rows[i].Table.Columns[x].ColumnName == "YourColumnName") 
           { 
             //Get value with dataRow[x]
           }
          }//end 2nd for
         }//end 1st for
        }//end outer if.
