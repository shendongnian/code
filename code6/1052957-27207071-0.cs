    public AddressImportRepository(FairFlexxDbContext context)
        : base(context, true)
    {
        IsUseSecurePredicate = true;
    }
    public bool IsUseSecurePredicate { get; set; }
