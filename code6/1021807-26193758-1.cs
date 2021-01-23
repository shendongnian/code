    [Test]
    public void ASingleTaskIsCompletedWhenTenAreScheduledWithinInterval()
    {
        var scheduler = new TestScheduler();
        var sampleDuration = TimeSpan.FromSeconds(1);
        var intervalRequestScheduler = new IntervalRequestScheduler(sampleDuration,
                                                                    scheduler);
        // use a helper method to create "requests"
        var taskFactories = Enumerable.Range(0, 10).Select(CreateRequest);
        // schedule the requests and collect the tasks into an array
        var tasks =
            (from tf in taskFactories
                select intervalRequestScheduler.ScheduleRequest(tf)).ToArray();
        // prove no tasks have completed
        var completedTasksCount = tasks.Count(t => t.IsCompleted);
        Assert.AreEqual(0, completedTasksCount);
        // this is the key - we advance time simulating a sampling period.
        scheduler.AdvanceBy(sampleDuration.Ticks);
        // now we see exactly one task has completed
        completedTasksCount = tasks.Count(t => t.IsCompleted);
        Assert.AreEqual(1, completedTasksCount);
    }
    // helper to create requests
    public Func<Task<int>> CreateRequest(int result)
    {
        return () => Task.Run(() => result);
    }
