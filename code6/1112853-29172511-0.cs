	bool IsFileAvailable(string fileName)
	{
		FileStream stream = null;
		try
		{
			FileInfo fileInfo = new FileInfo(fileName);
			stream = fileInfo.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
		}
		catch (IOException)
		{
			// File is not present, or locked by another process
			return false;
		}
		finally
		{
			if (stream != null)
				stream.Close();
		}
		// File is present and not locked
		return true;
	}
