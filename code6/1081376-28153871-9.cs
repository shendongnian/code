	DbCommand IProvider.GetCommand(Expression query) 
	{
		this.CheckDispose();
		this.CheckInitialized();
		if (query == null) {
			throw Error.ArgumentNull("query");
		}
		this.InitializeProviderMode();
		SqlNodeAnnotations annotations = new SqlNodeAnnotations();
		QueryInfo[] qis = this.BuildQuery(query, annotations);
		QueryInfo qi = qis[qis.Length - 1];
		DbCommand cmd = this.conManager.Connection.CreateCommand();
		cmd.CommandText = qi.CommandText;
		cmd.Transaction = this.conManager.Transaction;
		cmd.CommandTimeout = this.commandTimeout;
		AssignParameters(cmd, qi.Parameters, null, null);
		return cmd;
	}	
