    [TestMethod]
    public void TestThrowFromAsyncMethod()
    {
        var asyncObject = new AsyncClass();
        Action action = () =>
        {
            Func<Task> asyncFunction = async () =>
            {
                await asyncObject.ThrowAsync<ArgumentException>();
            };
            asyncFunction.ShouldNotThrow();
        };
    
        action.ShouldNotThrow();
    }
