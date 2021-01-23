    var bulk = new BulkOperations();
    var records = GetRecordsToUpdate();
    
    bulk.Setup<MyTable>()
    .ForCollection(records)
    .WithTable("MyTable")
    .AddColumn(x => x.SomeColumn1)
    .AddColumn(x => x.SomeColumn2)
    .BulkUpdate()
    .MatchTargetOn(x => x.Identifier)
