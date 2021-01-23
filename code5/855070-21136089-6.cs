    public AddressMap()
    {
        HasMany(x => x.Companies)
         ...
    }
    public CompanyMap()
    {
        HasMany(x => x.Addresses)
         ...
    }
    public AddressCompanyMap()
    {
        References(x => x.Address)..
        References(x => x.Company)..
         ...
    }
