    async Task<bool> ReadUrlAsync()
    {
      using (var client = new HttpClient())
      {
        client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
        using (var response = await client.GetAsync(request_url))
        {
          var data = await response.Content.ReadAsStringAsync();
          return true;
        }
      }
    }
