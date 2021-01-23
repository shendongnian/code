    class Data { public string Name; public string Inner; };
    // Test data
    var data = new Data[] 
    {
        new Data {Name = "Name1", Inner = "InnerName1"},
        new Data {Name = "Name1", Inner = "InnerName2"},
        new Data {Name = "Name2", Inner = "InnerName1"},
        new Data {Name = "Name2", Inner = "InnerName2"}
    };
    // remove duplicate Names
    var filtered = data.Aggregate(
        Enumerable.Empty<Data>(),
        (list, newitem) => list.Concat(new Data[] {new Data {
            Name = (list.Any() && list.Last().Name == newitem.Name)
                    ? null : newitem.Name,
            Inner = newitem.Inner
        }}));
