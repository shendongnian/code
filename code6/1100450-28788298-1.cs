    public static class DataFromAPI
    { 
        public void Retrieve()
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage();
                var result = client.GetAsync("http://url-of-my-api").Result;
                if (result.IsSuccessStatusCode)
                {
                    var responseContent = result.Content;   
                }
                DownloadCompleted(result.Content.ReadAsStringAsync().Result);
            }
            catch {}
        }
    }
