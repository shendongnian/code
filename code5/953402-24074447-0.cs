	private static readonly object _lock = new object();
	public static void StoreFourSqaureMetadata(string Id)
	{
		var noDataAvailable = "No data available".Trim();
		lock(_lock)
		{
			try
			{               
				var d = IsExist(Id); //Checking if Id already exist in Table
				if (d != null) 
					return;
				//If not add to table
			}
			catch { }
		}
	}
