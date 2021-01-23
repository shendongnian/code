        public override void Up()
        {
            Sql("ALTER TABLE dbo.Company DROP CONSTRAINT DF__Company__ColumnT__47DBAE45"); // Manually added
            AlterColumn("dbo.Company", "ColumnToConvert", c => c.Int(nullable: false, defaultValue: 2));
        }
        public override void Down()
        {
            Sql("ALTER TABLE dbo.Company DROP CONSTRAINT DF__Company__ColumnT__47DBAE45");  // Manually added
            AlterColumn("dbo.Company", "ColumnToConvert", c => c.Boolean(nullable: false, defaultValue: true));
        }
