    [TestMethod]
    public void TestThrowFromAsyncMethod()
    {
        Func<Task> asyncFunction = async () =>
        {
            await asyncObject.ThrowAsync<ArgumentException>();
        };
    
        asyncFunction.ShouldNotThrow();
    }
