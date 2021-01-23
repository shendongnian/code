private void ProcessImportedData()
{
	SqlConnection connection = null;	
	try
	{
		connection = new SqlConnection(this.sqlConnectionString);
		if (connection.State != ConnectionState.Open)
		{
			connection.Open();
		}
		SqlTransaction transaction = connection.BeginTransaction();
		using (SqlCommand processingCommand = connection.CreateCommand())
		{
			processingCommand.Transaction = transaction;
			processingCommand.CommandTimeout = 10000;
			processingCommand.CommandText = "dbo.StoredProcedure ";
			processingCommand.CommandType = CommandType.StoredProcedure;
			processingCommand.ExecuteNonQuery();			
			result.Success = true
		}
		transaction.Commit();
	}
	catch (Exception ex)
	{
		result.Success = false;		
	}
	finally
	{
		if (connection != null)
		{
			connection.Close();
			
		}
	}
}
