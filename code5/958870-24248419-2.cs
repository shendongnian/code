	static void Main(string[] args)
	{
		string filename = @"C:\Users\Public\Music\Sample Music\Ping.wav";
		string tmp = "";
		SoundPlayer sp;
		if (File.Exists(filename))
		{
			byte[] filebytes = File.ReadAllBytes(filename);
			Console.WriteLine("filebytes length: " + filebytes.Length);
			//tmp = Convert.ToBase64String(File.ReadAllBytes(filename), Base64FormattingOptions.None);
			tmp = System.Text.Encoding.BigEndianUnicode.GetString(File.ReadAllBytes(filename));
			Console.Write("string length: " + tmp.Length);
			//sp = new SoundPlayer(new MemoryStream(filebytes));
			//sp.Play();
			Console.ReadLine();
			byte[] bytes = System.Text.Encoding.BigEndianUnicode.GetBytes(tmp);//Encoding.ASCII.GetBytes(tmp);
			Console.WriteLine("bytes length: " + bytes.Length);
			sp = new SoundPlayer(new MemoryStream(bytes));
			sp.Play();
			Console.ReadLine();
		}
	}
