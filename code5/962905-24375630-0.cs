    public partial class AddGroupIsOnline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "IsOnline", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Groups", "IsOnline");
        }
    }
