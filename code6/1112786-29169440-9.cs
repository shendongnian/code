    [Expandable]
    static string GetAddressLine1(Address address)
    {
        // Not necessary to implement, see linked answer
        throw new NotImplementedException();
    }
    static Expression<Func<Address, string>> GetAddressLine1Expression()
    {
        return x => x.AddressLine1 == null || x.AddressLine1.TrimEnd() == string.Empty ? "Medical Office" : x.AddressLine1;
    }
