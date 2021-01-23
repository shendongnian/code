    [Index("ClientAddressIndex", IsUnique = true, Order = 1)]
    [Index("ClientCompanyIndex", IsUnique = true, Order = 1)]
    public int ClientId { get; set; }
    [Index("ClientCompanyIndex", IsUnique = true, Order = 2)]
    public int CompanyId { get; set; }
    [Index("ClientAddressIndex", IsUnique = true, Order = 2)]
    public int AddressId { get; set; }
