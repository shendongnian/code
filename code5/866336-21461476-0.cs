        public override void Up()
        {
            RenameTable(name: "dbo.Companies", newName: "CompanyBeers");
            DropForeignKey("dbo.Companies", "Beer_BeerID", "dbo.Beers");
            DropIndex("dbo.Companies", new[] { "Beer_BeerID" });
            CreateIndex("dbo.CompanyBeers", "Company_CompanyID");
            CreateIndex("dbo.CompanyBeers", "Beer_BeerID");
            AddForeignKey("dbo.CompanyBeers", "Company_CompanyID", "dbo.Companies", "CompanyID", cascadeDelete: true);
            AddForeignKey("dbo.CompanyBeers", "Beer_BeerID", "dbo.Beers", "BeerID", cascadeDelete: true);
            DropColumn("dbo.Companies", "Beer_BeerID");
        }
