    var newItems = new Dictionary<string, string>();
    newItems.Add("item2","world");
    client.Update<Data, object>(u => u
                .Index("defaultindex")
                .Type("data")
                .Document(newItems)
                .Id(d.Id)
                .RetryOnConflict(5)
                .Refresh()
                );
