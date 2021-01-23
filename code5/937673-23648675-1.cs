    bool flag = false;
    try
    {
    	this.InjectInterceptionContext(legacyHistoryContext);
    	using (new TransactionScope(TransactionScopeOption.Suppress))
    	{
    		(
    			from h in legacyHistoryContext.History
    			select h.CreatedOn).FirstOrDefault<DateTime>(); // Will throw an exception if the column is absent
    	}
    	flag = true;
    }
    catch (EntityException)
    {
    }
    if (flag)
    {
    	// Remove the column if present (if no exception was thrown)
    	yield return new DropColumnOperation("dbo.__MigrationHistory", "CreatedOn", null);
    }
