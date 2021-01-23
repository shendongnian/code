	/// <summary>
	/// Sets up a SqlDependency and doesn't return until it receives 
	/// a Change notification
	/// </summary>
	private static void WaitForWork(string connString)
	{
		var changedEvent = new AutoResetEvent(false);
		OnChangeEventHandler dataChangedDelegate = (sender, e) => changedEvent.Set();
		using (var conn = new SqlConnection(connString))
		{
			using (var scope = Databases.TransactionUtils.CreateTransactionScope())
			{
				conn.Open();
				var txtCmd = "SELECT [FileID] FROM dbo.[File] WHERE [Status] = 'ready'";
				using (var cmd = new SqlCommand(txtCmd, conn))
				{
					var dependency = new SqlDependency(cmd);
					OnChangeEventHandler dataChangedDelegate = null;
					dataChangedDelegate = (sender, e) =>
					{
						dependency.OnChange -= dataChangedDelegate;
						changedEvent.Set();
					};
					dependency.OnChange += dataChangedDelegate;
					cmd.ExecuteScalar();
				}
				scope.Complete();
			}
		}
		changedEvent.WaitOne();
		dependency.OnChange -= dependencyOnDataChangedDelegate;
	}
