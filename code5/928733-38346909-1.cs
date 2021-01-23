        public partial class AddMyStoredProcedure : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                CREATE PROCEDURE dbo.GetMyAddress
                AS
                SELECT * FROM Person.Address");
        }
        
        public override void Down()
        {
            Sql("DROP PROCEDURE dbo.GetMyAddress");
        }
    }
