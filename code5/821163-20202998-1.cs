    HttpResponseMessage response = client.GetAsync("api/products").Result;  // Blocking call!
    if (response.IsSuccessStatusCode)
    {
        // Parse the response body. Blocking!
        var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
        foreach (var p in products)
        {
            Console.WriteLine("{0}\t{1};\t{2}", p.Name, p.Price, p.Category);
        }
    }
