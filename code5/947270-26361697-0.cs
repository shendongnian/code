    public override void Up()
        {
            CreateTable(
                "Offers",
                c => new
                    {
                        OfferNo = c.Int(nullable: false, identity: true),
                        ...
                    })
                .PrimaryKey(t => t.OfferNo);
            Sql("DBCC CHECKIDENT ('Offers', RESEED, 100);");
        }
