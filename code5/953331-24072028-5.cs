	public static int Main(string [] args)
	{
		var service = new LiveShazamService("http://www.shazam.com");
		
		var parser = new ShazamMp3Parser(service);
		
		var mp3Data = args[0].ToByteArray();
		
		Console.Writeline(parser.Parse(mp3Data));
	}
