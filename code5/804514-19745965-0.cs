    public class DataService
    {
      public HttpClient CreateHttpClient()
      {
           var client = new HttpClient();
           client.MaxResponseContentBufferSize = 256000;
           client.Timeout = TimeSpan.FromSeconds(100);
           // I'm not sure why you're adding this, I wouldn't
           client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
           return client;
      }
    
      public async Task<List<Categories>> GetDefaultCategories()
      {
            var client = CreateHttpClient();
            HttpResponseMessage getresponse = await client.GetAsync(ServerBaseUri + "Categorys");                      
            string json = await getresponse.Content.ReadAsStringAsync();         
            json = json.Replace("<br>", Environment.NewLine);
            var categories = JsonConvert.DeserializeObject<List<Categories>>(json);
            return categories.ToList();
      }
    }
