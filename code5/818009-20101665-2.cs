    public override void Up()
    {
        DropForeignKey("dbo.Foos", "BarID", "dbo.Bars");
        DropIndex("dbo.Foos", new[] { "BarID" });
        CreateTable(
            "dbo.Bazs",
            c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    ApprovedBy = c.Int(nullable: false),
                    Name = c.String(),
                    BarID = c.Int(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
            .PrimaryKey(t => t.ID)
            .ForeignKey("dbo.Bars", t => t.BarID)
            .Index(t => t.BarID);
        //Put your sql here to run before the table is dropped
        Sql(@"INSERT INTO dbo.Bazs (Name, BarID, Discriminator) 
              SELECT Name, BarID, 'Foo' FROM dbo.Foos");
            
        DropTable("dbo.Foos");
    }
