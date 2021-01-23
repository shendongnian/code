    using (var client = new HttpClient())
     {
         HttpResponseMessage response = await client.GetAsync(new Uri(url));
         var json = await response.Content.ReadAsStringAsync();
         var result = JsonConvert.DeserializeObject<ODataResponse<Product>>(json);
         var products = result.Value;
     }
