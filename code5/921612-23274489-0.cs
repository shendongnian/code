    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("http://localhost/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        inventoryResponse = await client.PostAsJsonAsync("Inventory", inventoryRequest).Result.Content.ReadAsAsync<InventoryResponse>();
    }
