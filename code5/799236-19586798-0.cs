    DataTable dtTable = new DataTable();
    SqlConnection myLocalConnection = new SqlConnection(_ConnectionString);
    SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter("Select * from " + dtTable.TableName, myLocalConnection);
     
     mySqlDataAdapter.Fill(dtTable,"Products" ) 
    SqlCommandBuilder mySqlCommandBuilder = new SqlCommandBuilder(mySqlDataAdapter);
    
     mySqlDataAdapter.Update(dtTable);
