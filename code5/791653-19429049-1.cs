    private async Task<KeyValuePair<string, List<string>>> GetCustomOptionList(string key,
                                        HttpClient client, SearchMetadata sm)
    {
        sm.OptionFieldName = key;
        var response = await HttpClientExtensions
                          .PostAsJsonAsync(client, CatalogSpecificOptionPath, sm)
                          .Result.Content.ReadAsStringAsync();
        return new KeyValuePair<string, List<string>>(key,
                    Newtonsoft.Json.JsonConvert
                                .DeserializeObject<List<string>>(response));
    }// end task
