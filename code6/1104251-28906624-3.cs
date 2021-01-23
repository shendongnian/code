    CreateTable("dbo.RoleDependents",
        c => new
            {
                Id = c.String(nullable: false, maxLength: 128),
            })
        .PrimaryKey(t => t.Id)
        .ForeignKey("dbo.AspNetRoles", t => t.Id)
        .Index(t => t.Id);
