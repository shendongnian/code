    var updateDocument = new System.Dynamic.ExpandoObject();
    var newItems = new Dictionary<string, string>();
    newItems.Add("item2","world");
    updateDocument.Items = newItems;
    client.Update<Data, object>(u => u
                .Index("defaultindex")
                .Type("data")
                .Document(updateDocument)
                .Id(d.Id)
                .RetryOnConflict(5)
                .Refresh()
                );
