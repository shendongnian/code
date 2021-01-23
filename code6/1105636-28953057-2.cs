    CreateTable(
        "dbo.PrimaryEntities",
        c => new
            {
                Id = c.Guid(nullable: false),
            })
        .PrimaryKey(t => t.Id);
    CreateTable(
        "dbo.RelatedEntities",
        c => new
            {
                PrimaryEntityId = c.Guid(nullable: false),
            })
        .PrimaryKey(t => t.PrimaryEntityId)
        .ForeignKey("dbo.PrimaryEntities", t => t.PrimaryEntityId)
        .Index(t => t.PrimaryEntityId);
