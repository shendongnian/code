    public T Get<T>(string url, IEnumerable<KeyValuePair<string, string>> data)
    {
        var webApiUri = ConfigurationManager.AppSettings["WebApiUri"];
        
        var client = new HttpClient();
    
        try
        {
            string queryString = string.Empty;
    
            if (data != null)
            {
                queryString = data.Distinct().Select(x => string.Format("{0}={1}", x.Key, x.Value)).ToDelimitedString("&");
            }
    
            var response = client.GetAsync(string.Format("{0}/{1}?{2}", webApiUri, url, queryString)).Result;
            var responseContent = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
        catch (Exception ex)
        {
            Debug.Assert(false, ex.Message);
            throw;
        }
    }
