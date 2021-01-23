     public async Task<string> PostMultipleCustomers()
     {
            var customers = new List<Customer>
            {
                new Customer { Name = "John Doe" },
                new Customer { Name = "Jane Doe" },
            };
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("http://<Url>/api/Customers", customers);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return result;
                }
                return response.StatusCode.ToString();              
             }
    }
