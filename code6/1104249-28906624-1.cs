    CreateTable("dbo.RoleDependents",
    c => new
        {
            Id = c.Int(nullable: false, identity: true),
            IdentityRole_Id = c.String(maxLength: 128),
        })
    .PrimaryKey(t => t.Id)
    .ForeignKey("dbo.AspNetRoles", t => t.IdentityRole_Id)
    .Index(t => t.IdentityRole_Id);
