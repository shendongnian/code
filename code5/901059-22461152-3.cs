    public async Task<IEnumerable<ICar>> GetCarsAsync(string search)
    {
        // ...
        return JsonConvert.DeserializeObject<List<CarApiA>>(content);
    }
