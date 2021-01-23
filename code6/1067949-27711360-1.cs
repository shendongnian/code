    public override void Up()
    {
        this.AlterStoredProcedure("dbo.EditItem", c => new
        {
            ItemID = c.Int(),
            ItemName = c.String(),
            ItemCost = c.Decimal(precision: 10, scale: 4, storeType: "smallmoney")
        },
        @" (New sproc body SQL goes here) ");
    }
