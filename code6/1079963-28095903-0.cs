    searchTerm = Request.QueryString["RNum"];
    string sqlSelect = "SELECT COUNT(NoEmpl) FROM DTool Where NoEmpl= @NoEmpl";
     
    SqlConnection sqlConnection = new SqlConnection(sqlConnectString);
    SqlCommand sqlCommand = new SqlCommand(sqlSelect, sqlConnection);
    
    // Set SqlDbType based on your DB column Data-Type 
    sqlCommand.Parameters.Add("@NoEmpl", System.Data.SqlDbType.Varcahr);
    
    
     sqlCommand.Parameters["@NoEmpl"].Value = searchTerm ;
