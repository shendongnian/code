    CreateTable(
        "dbo.Categories",
        c => new
            {
                Id = c.Int(nullable: false, identity: true),
                Name = c.String(),
                CoverPicture_Id = c.Guid(),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.Pictures", t => t.CoverPicture_Id)
        .Index(t => t.CoverPicture_Id);
            
    CreateTable(
        "dbo.Pictures",
        c => new
            {
                Id = c.Guid(nullable: false),
                FileName = c.String(),
                Category_Id = c.Int(nullable: false),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
        .Index(t => t.Category_Id);
