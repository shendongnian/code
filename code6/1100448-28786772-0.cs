    public class DataService : IDataService
    {
        private IEnumerable<Concert> _concerts;
        public async Task LoadData()
        { 
            _concerts = await DataFromAPI.Retrieve();
            **other tasks that need the json**
        }
    }
	public static class DataFromAPI
	{ 
		public static async Task<IEnumerable<Concert>> Retrieve()
		{
			try
			{
				HttpClient client = new HttpClient();
				HttpRequestMessage request = new HttpRequestMessage();
				var result = await client.GetAsync(new Uri("http://url-of-my-api"), HttpCompletionOption.ResponseContentRead);
				string jsonstring = await result.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<IEnumerable<Concert>>(response.ToString());
			}
			catch(Exception)
			{
			}
            return Enumerable.Empty<Concert>();
		}
	}
