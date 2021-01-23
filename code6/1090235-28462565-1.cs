    public partial class AddBooleanProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "ColumnToConvert", c => c.Boolean(nullable: false, defaultValue: true));
        }
        public override void Down()
        {
            DropColumn("dbo.Company", "ColumnToConvert");
        }
    }
