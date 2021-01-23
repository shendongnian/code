            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardID = c.Int(nullable: false),
                        ContactID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardID)
                .ForeignKey("dbo.Contacts", t => t.CardID)
                .Index(t => t.CardID);
            
