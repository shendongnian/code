	public static SqlDataReader ExecuteReader(this SqlCommand command, CommandBehavior commandBehavior, CancellationToken cancellationToken)
	{
		try
		{
			using (cancellationToken.Register(command.Cancel))
				return command.ExecuteReader(commandBehavior);
		}
		catch (SqlException) when (cancellationToken.IsCancellationRequested)
		{
			throw new OperationCanceledException(cancellationToken);
		}
	}
