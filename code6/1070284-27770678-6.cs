    private async Task GetCustomer()
    {
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync("");
            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                ApplicationVM.customer = JsonConvert.DeserializeObject<Customer>(json);
            }
            else
            {
                Console.Write("api fail");
            }
        }
    }
