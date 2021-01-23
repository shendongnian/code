    public partial class PrecisionChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SomeTable", "Amount", (c => c.Decimal(false, 18, 3)));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SomeTable", "Amount", (c => c.Decimal(false, 18, 2)));
        }
    }
