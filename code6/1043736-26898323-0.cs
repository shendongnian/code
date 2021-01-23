    async Task UseSomething1Async(string someParameter)
    {
        // if IsNullOrWhiteSpace throws an exception, it will be wrapped in
        // the task and not thrown here.
        Task t1 = DoSomething1Async(someParameter);
        // rather, it'll get thrown here. this is best practice,
        // it's what users of Task-returning methods expect.
        await t1;
        // if IsNullOrWhiteSpace throws an exception, it will
        // be thrown here. users will not expect this.
        Task t2 = DoSomething2Async(someParameter);
    }
