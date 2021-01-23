    string indexName = "so-27927069";
    
    // --- create index ---
    client.CreateIndex(cid => cid.Index(indexName));
    Console.WriteLine("created index");
    
    // --- define map ---
    client.Map<MyType>(m => m
        .Index(indexName)
        .Type("myType")
        .MapFromAttributes());
    Console.WriteLine("set mapping");
    
    // ---- index -----
    client.Index<MyType>(
        new MyType
        {
            DateToBeUsed = new DateTime(2012, 5, 21, 9, 51, 34, 73)
                .ToString("yyyy-MM-ddThh:mm:ss.fff"),
            ElasticId = "2"
        },
        i => i
            .Index(indexName)
            .Type("myType")
            .Id(2)
    );
    Console.WriteLine("doc indexed");
    
    // ---- get -----
    var doc = client.Get<MyType>(i => i
            .Index(indexName)
            .Type("myType")
            .Id(2)
        );
    
    Console.WriteLine();
    Console.WriteLine("doc.Source.DateToBeUsed: ");
    Console.WriteLine(doc.Source.DateToBeUsed);
    Console.WriteLine();
    Console.WriteLine("doc.RequestInformation.ResponseRaw: ");
    Console.WriteLine(Encoding.UTF8.GetString(doc.RequestInformation.ResponseRaw));
