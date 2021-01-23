      using (var scope = new System.Transactions.TransactionScope(TransactionScopeOption.Required))
      {
	var outputStatus = new List<string>();
	for (int i = 0 ; i < 5 ; i++)
	{
	   //Note RequiredNew, rest of the arguments suppressed 
		using (var innerScope = new System.Transactions.TransactionScope(TransactionScopeOption.RequiredNew))
		{
			try
			{
				
				// Do work here that causes an exception on first iteration only <-- is this really the case or is just an example, if so could you skip the first one?
				SomeService.DoSOmetaskWhichUsesATransactionInsideOfIt(i);
				outputStatus.Add("SUCCESS : " + i );
                                innerScope.Complete();
				
			}
			catch (Exception e)
			{
				outputStatus.Add("ERROR, "  + i + "   " + e.Message);
			}
		}
		
	}
	// IN here you must inspect outputStatus and decide if you want to complete the transaction (all of it , or the parts that didn't fail) or not. 
	if(/* all good */) {
		scope.Complete();
	}
	// Print out outputStatus values here
    }
