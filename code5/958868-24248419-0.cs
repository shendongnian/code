	static void Main(string[] args)
	{
		string filename = @"C:\Users\Public\Music\Sample Music\Kalimba.mp3";
		if (File.Exists(filename))
		{
			string tmp = Convert.ToBase64String(File.ReadAllBytes(filename), Base64FormattingOptions.None);
			Console.Write(tmp);
		}
		Console.ReadLine();
	}
