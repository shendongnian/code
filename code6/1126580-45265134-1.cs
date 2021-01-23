        CreateTable(
            "dbo.Companies",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ...
                    UserId = c.String(nullable: false, maxLength: 128),
                    
                })
            .PrimaryKey(t => t.Id)
            ....
            .ForeignKey("dbo.AspNetUsers", t => t.UserId)
            ...
            .Index(t => t.UserId);
