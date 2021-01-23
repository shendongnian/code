    public partial class CodeHostDiscovery : DbMigration
    {
        public override void Up()
        {
            var batches = Properties.Resources.CodeHostDiscoverySqlScript.Split(new string[] {"GO--BATCH--"}, StringSplitOptions.None);
            foreach (var batch in batches)
            {
                Sql(batch);    
            }
        }
        
        public override void Down()
        {
        }
    }
