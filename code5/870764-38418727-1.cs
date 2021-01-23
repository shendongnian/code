    public partial class Add_unique_index : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Person", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Person", new[] { "Name" });
        }
    }
