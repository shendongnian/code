    public ItemSaleDetailMap()
    {
        ...
        Id(x => x.ItemSaleCode)
            .CustomType<String>()
            .Column("SaleCode")
            .GeneratedBy.Assigned();
        HasOne(x => x.SaleParent)
           .ProeprtyRef("SaleCode")
           .Constrained(); 
    }
    public ItemSaleMap()
    {
        References(x => x.SaleDetail)
           .Column("SaleCode")
           .Unique()
           .Cascade.All();
        Map(x => x.SaleCode)
           .Column("SaleCode")
           .Not.Update()
           .Not.Insert()
    }
