    using (OracleCommand cmd = new OracleCommand())
    {
        cmd.Connection = connection;
        cmd.Transaction = transaction;
    	foreach (var item in _tableNameAndColumnsList)
    	{
    		if (item.Replace)
    		{
    			cmd.CommandText = "UPDATE TABLE TEST WHERE id_test = "+id_test+" "; /*Assuming this is only test command*/
                rowsInserted += cmd.ExecuteNonQuery();
    	    }
        }
    }
