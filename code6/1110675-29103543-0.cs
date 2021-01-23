    var queue = Dictionary(Subscriber, List<SomeData>);
    //And lets just for example add some data
    var items1 = new List<SomeData>();
    items1.Add(new SomeData("test"));
    items1.Add(new SomeData("test2"));
    var items2 = new List<SomeData>();
    items2.Add(new SomeData("test"));
    queue.Add(new Subscriber("Peter"), items1);
    queue.Add(new Subscriber("Luke"), items1);
    queue.Add(new Subscriber("Anna"), items2);
    Dictionary<Subscriber, List<SomeData>> myDictionary = queue
        .GroupBy(o => o.PropertyName)
        .ToDictionary(g => g.Key, g => g.ToList());
