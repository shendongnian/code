        CreateTable(
            "dbo.Companies",
            c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ...
                    UserId = c.String(),
                    User_Id = c.String(nullable: false, maxLength: 128),
                })
            .PrimaryKey(t => t.Id)
            ...
            .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
            ...
            .Index(t => t.User_Id);
