    public async void TestMethod()
    {
        //arrange
        var listToAdd = new List<object>() { new object() };
        var queue = new QueueWrapper<object>();
        var inMemoryQueue = new InMemoryQueue(queue);
        //act
        await inMemoryQueue.AddToAsync(listToAdd);
        //assert
        Assert.IsTrue(queue.Count == 1);
    }
