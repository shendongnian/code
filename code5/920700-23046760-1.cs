    public static async Task<string> httpRequest(HttpWebRequest request)
    {
      var httpClient = new httpClient();
      var response = await httpClient.GetAsync("http://www.google.com")
      var stringResult = await response.Content.ReadStringAsync();
    
      return stringResult;
    }
 
