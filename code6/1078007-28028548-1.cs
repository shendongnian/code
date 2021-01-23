    [Test]
    public async Task VerifyTask()
    {
        var tcs = new TaskCompletionSource<bool>();
        var keepAliveTask = tcs.Task;
        // verify pre-condition
        Assert.IsFalse(keepAliveTask.IsCompleted);
        var waitTask = Task.Run(async () => await keepAliveTask);
        tcs.SetResult(true);
        await waitTask;
        // verify keepAliveTask has finished, and as such has been awaited
        Assert.IsTrue(keepAliveTask.IsCompleted);
        Assert.IsTrue(waitTask.IsCompleted); // not needed, but to make a point
    }
