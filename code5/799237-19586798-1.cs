        DataTable dtTable = new DataTable();
        SqlConnection myLocalConnection = new SqlConnection(_ConnectionString);
     
        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter("Select * from " +   
        dtTable.TableName, myLocalConnection); 
 
        SqlCommandBuilder builder= new SqlCommandBuilder(mySqlDataAdapter);     
        mySqlDataAdapter.Fill(dtTable,"Products" ) 
         // Code to modify your datatable
        mySqlDataAdapter.UpdateCommand = builder.GetUpdateCommand();  
        
        mySqlDataAdapter.Update(dtTable);
