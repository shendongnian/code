    public async Task<CustomerMVC> GetCustomer()
    {
        //return control to caller until GetAsync has completed
        var task = await client.GetAsync("api/values");
        //return control to caller until ReadAsStringAsync has completed
        var result = await task.Content.ReadAsStringAsync()
        return JsonConvert.DeserializeObject<CustomerMVC>(result);
    }
