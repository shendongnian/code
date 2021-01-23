    static void Main() {
    	try {
    		using(SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConn.ConnectionString, SqlBulkCopyOptions.KeepIdentity | SqlBulkCopyOptions.UseInternalTransaction)) {
    			//Event handling
    			bulkCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);
    			bulkCopy.NotifyAfter = 50; //Put your rowcount here
    
    			bulkCopy.DestinationTableName = "MyDestinationTable";
    			bulkCopy.WriteToServer(dt);
    			convertSuccess = true;
    		}
    	} catch {
    		convertSuccess = false;
    	}
    }
    
    
    private static void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs e) {
    	Console.WriteLine("Copied {0} so far...", e.RowsCopied);
    }
