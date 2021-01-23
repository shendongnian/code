    public async Task<JObject> GetResponseAsync(JObject request, TimeSpan timeout)
    {
      var endpoint = ConfigurationManager.AppSettings.Get("MyEndPoint");
      try
      {
        using (var client = new HttpClient())
        {
          client.DefaultRequestHeaders.Accept.Clear();
          client.Timeout = timeout;
          IList<MediaTypeFormatter> formatters = GetMediaTypeFormatters();
          HttpResponseMessage response = await client.PostAsJsonAsync(EndPoint, request);
          if (response.IsSuccessStatusCode)
            return await response.Content.ReadAsAsync<T>(formatters);
          throw new Exception(response.ReasonPhrase);
        }
      }
      catch (Exception ex)
      {
        return new JObject()
        {
          new JProperty("Exception", "Invalid response. " + ex.Message)
        };
      }
    }
