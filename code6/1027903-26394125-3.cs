            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        DefaultBillingAddressID = c.Int(),
                        DefaultShippingAddressID = c.Int(),
                        DefaultCreditCardID = c.Int(),
                    })
                .PrimaryKey(t => t.ContactID)
                .ForeignKey("dbo.Addresses", t => t.DefaultBillingAddressID)
                .ForeignKey("dbo.Cards", t => t.DefaultCreditCardID)
                .ForeignKey("dbo.Addresses", t => t.DefaultShippingAddressID)
                .Index(t => t.DefaultBillingAddressID)
                .Index(t => t.DefaultShippingAddressID)
                .Index(t => t.DefaultCreditCardID);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardID = c.Int(nullable: false, identity: true),
                        ContactID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardID)
                .ForeignKey("dbo.Contacts", t => t.ContactID, cascadeDelete: true)
                .Index(t => t.ContactID);
