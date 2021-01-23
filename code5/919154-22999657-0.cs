    public partial class AddView : DbMigration
      {
        public override void Up()
        {
          this.CreateView("dbo.MyView1",
                          @"SELECT  id,myTable2Id
                            FROM    MyTable1 JOIN ...........);
        }
        public override void Down()
        {
          this.RemoveView("dbo.MyView1");
        }
      }
