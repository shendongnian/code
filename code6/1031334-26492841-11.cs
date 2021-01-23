    public partial class ModifyUser: DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NewField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NewColumn");
        }
    }
