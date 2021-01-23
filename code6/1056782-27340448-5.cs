    public interface IApiCaller
    {
        Task<T> Get<T>(string apiActionUrl);
    }
    
    public class ApiCaller : IApiCaller
    {
        private const string ApiBaseUrl = "http://myApiBaseUrl";
    
        public async Task<T> Get<T>(string apiActionUrl)
        {
            using (var client = GetHttpClient())
            {
                var response = await client.GetAsync(apiActionUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
            }
    
            return default(T);
        }
    
        private static HttpClient GetHttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseUrl),
            };
    
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
            return client;
        }
    }
