    SqlCommand sqlCommand = new SqlCommand(.........);
    sqlCommand.CommandText = "theStoredProcedureNameHere";
    sqlCommand.CommandType = CommandType.StoredProcedure;
    
    SqlParameter paramWhatever1 = new SqlParameter(......);
    SqlParameter paramWhatever2 = new SqlParameter(......);
    
    sqlCommand.Parameters.Add(paramWhatever1);
    sqlCommand.Parameters.Add(paramWhatever2);
    
    SqlDataAdapter sqlAdapter = new SqlDataAdapter();
    sqlAdapter.SelectCommand = sqlCommand;
    DataSet ds = new DataSet();
    sqlAdapter.Fill(ds);
