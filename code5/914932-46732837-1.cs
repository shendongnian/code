    foreach(Exception exInnerException in aggEx.Flatten().InnerExceptions)
	{
		Exception exNestedInnerException = exInnerException;
		do
		{
			if (!string.IsNullOrEmpty(exNestedInnerException.Message))
			{
		        Console.WriteLine(exNestedInnerException.Message);
            }
			exNestedInnerException = exNestedInnerException.InnerException;
		}
		while (exNestedInnerException != null);
	}
