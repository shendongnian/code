        public override void Up()
        {
            DropIndex("dbo.Companies", new[] { "Beer_BeerID" });
            DropForeignKey("dbo.Companies", "Beer_BeerID", "dbo.Beers");
            DropColumn("dbo.Companies", "Beer_BeerID");
            CreateTable(
                "dbo.CompanyBeers",
                c => new
                {
                    Company_CompanyID = c.Int(nullable: false),
                    Beer_BeerID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Company_CompanyID, t.Beer_BeerID })
                .ForeignKey("dbo.Companies", t => t.Company_CompanyID, cascadeDelete: true)
                .ForeignKey("dbo.Beers", t => t.Beer_BeerID, cascadeDelete: true)
                .Index(t => t.Company_CompanyID)
                .Index(t => t.Beer_BeerID);
        }
