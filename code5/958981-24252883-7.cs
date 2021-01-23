    CreateTable(
                "dbo.Foos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisplayOrder = c.Int(nullable: false),
                        Description = c.String(),
                        Package = c.String(),
                        TimeStamp = c.Binary(),
                        xyxFooType = c.String(maxLength: 128),
                        xyxLookupType = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
