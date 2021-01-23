	private void MyFunc(object item)
	{
		if (item == DBNull.Value)
		{
			// Do something
		}
		else if (item is string)
		{
		}
		else if (item is decimal)
		{
		}
		
		// etc.
	}
