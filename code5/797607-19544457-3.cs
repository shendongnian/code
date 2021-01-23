    var collection = new TransformCollection();
    collection.Add(SomeMethodToGetTransform<Task>());
    //...
    if (collection.Exists<Task>())
    {
       var transform = collection.Get<Task>();
       //...
    }
