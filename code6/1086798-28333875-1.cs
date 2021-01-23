    MemoryStream msData = null;
	try
	{
		msData = new MemoryStream(encodedData);
		try
		{
			using (BinaryWriter wtr = new BinaryWriter(msData))
			{
				wtr.Write(IV, 0, IV.Length);
				wtr.Write(encrypted, 0, encrypted.Length);
			}
		}
		finally
		{
			msData = null;
		}
	}
	finally
	{
		if (msData != null)
			msData.Dispose();
	}
