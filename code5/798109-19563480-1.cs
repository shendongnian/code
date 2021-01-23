    HttpClient client = new HttpClient();
    HttpResponseMessage response = await client.GetAsync("http://localhost:1234/api/items");
    var Items = new List<Items>();
    if (response.IsSuccessStatusCode)
    {
        IEnumerable<string> categories = await response.Content.ReadAsAsync<IEnumerable<string>>();
        var ItemData = new Items
                (
                    // Use this category list to initialize your Items
                );
        items.Add(ItemData);
    }
