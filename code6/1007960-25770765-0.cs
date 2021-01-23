    using (OleDbConnection conn= new OleDbConnection(connectionString))
    {
    	conn.Open();
    
        // set the commend type here	
    	command.CommandType = CommandType.StoredProcedure;
    
    	//set the command text (stored procedure name or SQL statement)
    	command.CommandText = "VOD_BULK_TRANS1";
    
    	command.Parameters.Add(new OleDbParameter("retVal", OleDbType.VarChar, 11, ParameterDirection.ReturnValue, true, 0, 0, "retVal", DataRowVersion.Current,null));
    	command.Parameters.Add( OleDbParameter("@t_list", videosListWithCommaSeparated);
    	command.Parameters.Add( OleDbParameter("@option1", 3);
    	command.Parameters.Add( OleDbParameter("@id1", groupId);
    	command.ExecuteNonQuery();
    
    }
