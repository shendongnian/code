	try
	{
		throw new CustomException("Invalid code.");
	}
	catch (CustomException ex)
	{
		System.Diagnostics.Trace.WriteLine("CustomException");
		throw;
	}
	catch (Exception ex)
	{
		throw;
	}
