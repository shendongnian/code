    public static async Task<string> GetRequestAsync(string url)
    {            
      using (var httpClient = new HttpClient() { MaxResponseContentBufferSize = int.MaxValue })
      {
        HttpResponseMessage response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
      }
    }
