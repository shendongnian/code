    SqlParameter storeID = new SqlParameter("@STORE_ID", SqlDbType.NVarChar);
    storeID.Direction = ParameterDirection.Input;
    storeID.Value = Properties.storeId;
    SqlConnection connection = new SqlConnection(Properties.сonnectionString);
    SqlCommand command = new SqlCommand("POS_STORED_OBJECTS_GET_SP", connection);
    command.CommandType = CommandType.StoredProcedure;
    command.Parameters.Add(storeID);
    
    SqlDataAdapter adapter = new SqlDataAdapter();
    adapter.SelectCommand = command;  
    
    DataSet dataSet = new DataSet();
    adapter.Fill(dataSet);
