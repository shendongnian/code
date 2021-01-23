    public class CreateIndexOnContactCodeMigration : DbMigration
    {
        public override void Up()
        {
            this.CreateIndex("Contacts", "Code");
        }
    
        public override void Down()
        {
            base.Down();
            this.DropIndex("Contacts", "Code");
        }
    }
