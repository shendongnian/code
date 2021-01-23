        public override void Up()
        {
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        EmailID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.EmailID);
            
            CreateTable(
                "dbo.BookingRequests",
                c => new
                    {
                        EmailID = c.Int(nullable: false),
                        Testing123 = c.String(),
                    })
                .PrimaryKey(t => t.EmailID)
                .ForeignKey("dbo.Email", t => t.EmailID)
                .Index(t => t.EmailID);
            
        }
