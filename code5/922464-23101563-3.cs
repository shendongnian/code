        using (var client = new HttpClient())
        {
            var postUri= "http://localhost/";
            client.BaseAddress = new Uri(postUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            inventoryResponse = client.PostAsJsonAsync("Inventory", inventoryRequest).Result.Content.ReadAsAsync<InventoryResponse>().Result;
        }
