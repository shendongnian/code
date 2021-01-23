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
            CreateIndex("dbo.Blogs", 
                        new[] { "Rating", "Title" }, 
                        clustered: true, 
                        name: "IdAndRating");
            
        }
