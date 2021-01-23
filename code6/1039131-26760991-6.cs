    List<dynamic> Documents = new List<dynamic>();
    //Populate Documents
    BulkDescriptor descriptor = new BulkDescriptor();
    foreach(var doc in Documents)
    {
        descriptor.Index<object>(i => i
            .Index("someindex")
            .Type("SomeType")
            .Id("someid")
            .Document(doc));
    }
    esClient.Bulk(descriptor);
