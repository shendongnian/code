    [Test]
    public void BlockingCallShouldBlock()
    {
        var task = Task.Run(() => SomeBlockingCall());
        var completedInTime = task.Wait(50); // Also an overload available for TimeSpan
        Expect(completedInTime, Is.False);
    }
