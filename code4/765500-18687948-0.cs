private void DoMassDataImport(DataTable tab)
 {            
	var conn = new SqlConnection(this.sqlConnectionString);
	try
	{
		if (conn.State != ConnectionState.Open)
		{
			conn.Open();
		}
		SqlTransaction transaction = conn.BeginTransaction();
		using (SqlBulkCopy copy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
		{
			copy.BulkCopyTimeout = 10000;
			copy.DestinationTableName = "dbo.TargetTable";
			copy.WriteToServer(tab);
		}
		transaction.Commit();
		result.Success = true;                
	}
	catch (Exception ex)
	{
		result.Success = false;
		this.LogEvent(ex.Message + Environment.NewLine + ex.StackTrace);
	}
	finally
	{
		conn.Close();                
	}
}
