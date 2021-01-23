        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 256),
                        Rating = c.Int(nullable: false),
                    });
                .PrimaryKey(t => t.Id)
                .Index(t => t.Rating, clustered: true, name: "IdAndRating");
        }
