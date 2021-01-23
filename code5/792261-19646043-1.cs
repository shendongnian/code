    HttpClient client = new HttpClient();
    // Send a request asynchronously and continue when complete
    HttpResponseMessage clientResult = await client.GetAsync(_address);
    // Check that response was successful or throw exception
    clientResult.EnsureSuccessStatusCode();
    // Read response asynchronously as JToken and write out top facts for each country
    string jsonString = await clientResult.Content.ReadAsStringAsync();
    OctopartObject obj = JsonConvert.DeserializeObject<OctopartObject>(jsonString);
