    var transactionScope = new TransactionScope
										(TransactionScopeOption.RequiresNew, 
											new TransactionOptions()
											{
												IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted
											}
										);
			try
			{
				using (transactionScope)
				{ ...etc
