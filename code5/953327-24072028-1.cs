	public class LiveShazamService : IShazamService
	{
		private readonly string _url;
		public LiveShazamService(string url)
		{
			_url = url;
		}
		
		public string IdentifySong(byte [] mp3Data)
		{
			return HttpHelper.Upload(url, mp3Data).Response;
		}	
	}
	
	
