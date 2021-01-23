      private async Task RunAsyncGet()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56286/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("/api/product/1");
                if (response.IsSuccessStatusCode)
                {
                    Product product= await response.Content.ReadAsAsync<Product>();
                    SomeLabel.Text = product.Username;
                  
                }
            }
        }
