	public byte[] GenerateCsv()
	{
		// ...
		return System.Text.Encoding.Default.GetBytes(data.getCSV());
	}
