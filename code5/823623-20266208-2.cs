    [Test]
    public void Can_Receive_Added_Items()
    {
        //arrange        
        var listToAdd = new List<object> { new object() };
        var inMemoryQueue = new InMemoryQueue();
        //act
        inMemoryQueue.AddToAsync(listToAdd).Wait();
        //assert
        var queuedItems = inMemoryQueue.ReceieveAsync(listToAdd.Count).Result;
        CollectionAssert.AreEqual(listToAdd, queuedItems);
    }
