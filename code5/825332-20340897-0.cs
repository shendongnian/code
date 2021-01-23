    [Test]
    public async Task DoSomething()
    {
        CallContext.LogicalSetData("id", "123");
        var id1 = CallContext.LogicalGetData("id");
        Console.WriteLine("ID1: " + id1);
        await Task.Delay(100);
        var id2 = CallContext.LogicalGetData("id");
        Console.WriteLine("ID2: " + id2);
    }
