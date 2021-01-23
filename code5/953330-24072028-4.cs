	public class ShazamMp3Parser
	{
		private readonly IShazamService _shazamService;
		
		public ShazamMp3Parser(IShazamService shazamService)
		{
			_shazamService = shazamService;
		}
		
		public ShazamParserResult Parse(byte[] mp3Data)
		{
			var rawText = _shazamService.IdentifySong(mp3Data);
			
			// bla bla bla (up to the viewer to implement properly)
			var title = rawText.SubString(24, 50);	
			
			return new ShazamParserResult { Title = title };
		}
	}
