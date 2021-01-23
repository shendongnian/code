    public IQueryable<Addresses> GetAddressesesForProvider(string provider_k, string addresstype_rtk)
    {
        var query = from a in this.Context.Addresses
            join pa in this.Context.ProviderAddresses on a.Address_K equals pa.Address_K
            where pa.Provider_K == provider_k &&
                  pa.AddressType_RTK == addresstype_rtk &&
                  pa.Active == true &&
                  a.Active == true
            select a;
    
        return query;
    }
