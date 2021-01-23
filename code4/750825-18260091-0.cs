    List<int> items = new List<int>();
    Action<int> act = i => { items.Add(i); };
    
    Enumerable.Range(0, 10).ForEach(act).ToList();
    
    Assert.That(items.Count, Is.EqualTo(10));
    ...
