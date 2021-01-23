    var rawCustomer = await GetRawCustomer();
    var populationWork = new List<Task>();
    Task<string> getCity;
    if (string.IsNullOrWhiteSpace(rawCustomer.City))
    {
        getCity = GetCity(rawCustomer);
        populationWork.Add(getCity);
    }
    Task<string> getZipCode;
    if (string.IsNullOrWhiteSpace(rawCustomer.City))
    {
        getZipCode = GetZipCode(rawCustomer);
        populationWork.Add(getZipCode);
    }
    
    ...
    await Task.WhenAll(populationWork);
    if (getCity != null)
        rawCustomer.City = getCity.Result;
    if (getZipCode != null)
        rawCustomer.ZipCode = getZipCode.Result;
