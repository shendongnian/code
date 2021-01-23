	private static string CopyData(string sourceConnection, string targetConnection, bool push = true)
	{
		string result = "Copy started";
		
		using (var source = new SqlConnection(sourceConnection))
		using (var target = new SqlConnection(targetConnection))
		{
			source.Open();
			target.Open();
			
			using (var transaction = target.BeginTransaction())
			{
				// do stuff, 
				
				// no need to rollback if exception occurs
				transaction.Commit();
			}
			
			// no need to close connections explicitly
		}
	}
