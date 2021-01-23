    HttpClient client = new HttpClient();
    var response = await client.GetAsync("url");
    if (response.IsSuccessStatusCode) {
      var getResponsestring = await.Content.ReadAsStringAsync();
    }
