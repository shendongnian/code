     public void AddCustomer(Customer customer)
        {
            String apiUrl = "Web api Address";
            HttpClient _client= new HttpClient();
            string JsonCustomer = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(JsonCustomer, Encoding.UTF8, "application/json");
            var response = _client.PostAsync(apiUrl, content).Result;
        }
 
