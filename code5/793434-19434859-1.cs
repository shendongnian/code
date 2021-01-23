	private static string CopyData(string sourceConnection, string targetConnection, bool push = true)
	{		
		using (var source = new SqlConnection(sourceConnection))
		using (var target = new SqlConnection(targetConnection))
		{
			source.Open();
			target.Open();
			// no need to check for open status, as Open will throw an exception if it fails
			
			using (var transaction = target.BeginTransaction())
			{
				// do work 
				
				// no need to rollback if exception occurs
				transaction.Commit();
			}
			
			// no need to close connections explicitly
		}
	}
