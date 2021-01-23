       CreateTable(
                    "dbo.Events",
                    c => new
                        {
                            EventID = c.Int(nullable: false, identity: true),
                            //etc
                        })
                    .PrimaryKey(t => t.EventID );
