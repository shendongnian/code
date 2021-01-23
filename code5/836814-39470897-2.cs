    var bulk = new BulkOperations();
    var records = GetRecordsToUpdate();
    using (TransactionScope trans = new TransactionScope())
    {
    	using (SqlConnection conn = new SqlConnection(ConfigurationManager
    	.ConnectionStrings["SqlBulkToolsTest"].ConnectionString))
    	{
            bulk.Setup<MyTable>()
                .ForCollection(records)
                .WithTable("MyTable")
                .AddColumn(x => x.SomeColumn1)
                .AddColumn(x => x.SomeColumn2)
                .BulkUpdate()
                .MatchTargetOn(x => x.Identifier)
                .Commit(conn);
    	}
    
    	trans.Complete();
    }  
