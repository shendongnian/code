	{
		SqlCommand temp = new SqlCommand(commandText,
			new SqlConnection(ConnectionString));
		try
		{
			// ...
		}
		finally
		{
			if (temp != null)
				((IDisposable)temp).Dispose();
		}
	}
	
