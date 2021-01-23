    public static async Task<string> GetRequestAsync(string url)
    {            
      var httpClient = new HttpClient() { MaxResponseContentBufferSize = int.MaxValue };
      return await httpClient.GetStringAsync(url);
    }
