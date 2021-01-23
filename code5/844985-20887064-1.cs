    public override void Up()
    {
        Sql("EXEC ('CREATE View [dbo].[ClientStatistics] AS --etc"
    }
    
    public override void Down()
    {
    
        Sql(@"IF  EXISTS (SELECT
        	                *
                        FROM sys.views
                        WHERE object_id = OBJECT_ID(N'dbo.ClientStatistics'))
                        DROP VIEW dbo.ClientStatistics)")
    }
