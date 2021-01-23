            public override void Up()
            {
                DropColumn("dbo.Cities", "RowVersion", null);
                AddColumn("dbo.Cities", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            }
            
            public override void Down()
            {
                AlterColumn("dbo.Cities", "RowVersion", c => c.Binary());
            }
       
