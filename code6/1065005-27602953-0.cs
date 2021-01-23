	public void Method1()
	{
	    foreach(var i in Method2(1))
		{
			if (i.Value == null)
			{
				// No Exception Thrown
			}
			else
			{
				// Exception Thrown
                SendEmail(); // Send a message
			}
		}		
	}
	
	public IEnumerable<KeyValuePair<int, Exception>> Method2(int id)
	{
		List<int> col = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		Exception exception;
		
	    foreach (var i in col)
	    {
			exception = null;
	        try
	        { 
				if ((i % 2) == 1)
				{
					throw new Exception("Test" + i);
				}
	            /*Do some stuff*/
	        }
	       	catch (Exception ex)
	       	{
				exception = ex;
	       	}
			
			yield return new KeyValuePair<int, Exception>(i, exception);
	    }
	}
