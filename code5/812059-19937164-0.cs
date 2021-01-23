    async public Task GetInformationAsync(string url)
    {
      var client = new HttpClient();
      var response = await client.GetAsync(new Uri(url));
      result = await response.Content.ReadAsStringAsync();
    }
