    public static Task<string> GetRequestAsync(string url)
    {            
      var httpClient = new HttpClient() { MaxResponseContentBufferSize = int.MaxValue };
      return httpClient.GetStringAsync(url);
    }
