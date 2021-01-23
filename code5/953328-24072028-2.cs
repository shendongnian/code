	public class MockShazamService : IShazamService
	{
		private readonly string _testData;
		
		public LiveShazamService(string testData)
		{
			_testData = testData;
		}
		public string IdentifySong(byte [] mp3Data)
		{
			return _testData;
		}	
	}
