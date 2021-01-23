    CreateTable(
        "dbo.CarEntities",
        c => new
            {
                Id = c.Int(nullable: false, identity: true),
                Name = c.String(),
            })
        .PrimaryKey(t => t.Id);
