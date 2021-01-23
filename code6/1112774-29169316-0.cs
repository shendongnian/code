    var adrsQuery = this.Context.Addresses
    .Where(a => myList.Contains(a.Address_K))
    .AsEnumerable()
    .Select(a => new AlternateAddressesDB
        {
            Line1 = GetAddressLine1(a.AddressLine1),
            Line2 = a.AddressLine2,
            City = a.City,
            State = a.State,
            ZipCode = a.ZipCode
        }).ToList();
    private static string GetAddressLine1(string adrs)
    {
        if (string.IsNullOrWhiteSpace(adrs))
            adrs = "Medical Office";
        return adrs;
    }
