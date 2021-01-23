    [Migration("1.0.1", 1, "YourTableName")]
      public class AddNewColumnToTable : MigrationBase
      {
        public AddNewColumnToTable(ISqlSyntaxProvider sqlSyntax, ILogger logger) 
          : base(sqlSyntax, logger)
        { }
    
        public override void Up()
        {
          Alter.Table("YourTableName").AddColumn("ColumnToAdd").AsString().Nullable();
        }
    
        public override void Down()
        {
          Delete.Column("ColumnToAdd").FromTable("YourTableName");
        }
      }
    
