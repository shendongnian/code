	{
		var temp = obj;
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
	
