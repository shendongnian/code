    public static async Task SendJsonDemo(object content)
    {
      using(var client = new HttpClient())
      {
        var response = await client.PostAsJsonAsync("https://example.com", content);
      }
    }
