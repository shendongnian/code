    HttpResponseMessage response = await client.GetAsync("api/products");
    if (response.IsSuccessStatusCode)
    {
        List<Product> products = await response.Content.ReadAsAsync<List<Product>>();
        foreach (var product in products)
        {
            Console.WriteLine(string.Join("\t",
                product.Name, product.Price, product.Category));
        }
    }
