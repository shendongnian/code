    public partial class AddView : DbMigration
      {
        public override void Up()
        {
          this.Sql(@"CREATE VIEW MyView1 AS ....");
        }
        public override void Down()
        {
            this.Sql(@"DROP VIEW MyView1....");
        }
      }
