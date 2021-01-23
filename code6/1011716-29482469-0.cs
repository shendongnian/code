    [Migration(01, TransactionBehavior.Default, "Testing creating a table with charset")]
    public class _0001_AddTableWithCharsetColumn : Migration
    {
        public override void Down()
        {
            Delete.Table("StackOverflow");
        }
        public override void Up()
        {
            var sql = @"CREATE TABLE StackOverflow
                        (
                            foo VARCHAR(5)
                                CHARACTER SET latin1
                                COLLATE latin1_german1_ci
                        );";
            Execute.Sql(sql);
        }
    }
