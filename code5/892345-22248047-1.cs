    public override void Up()
    {
        CreateTable(
            "dbo.Tests",
            c => new
                {
                    Id = c.Long(nullable: false, identity: true),
                    Title = c.String(nullable: false),
                    TestTypeId = c.Int(nullable: false),
                })
            .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.TestTypes", t => t.TestTypeId)
            .Index(t => t.TestTypeId);
        
        CreateTable(
            "dbo.TestTypes",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
            .PrimaryKey(t => t.Id);
    }
