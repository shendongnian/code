    [TestMethod]
    public void TestActionRunnerExecutesAction() {
        bool run = false;
        var runner = new ActionRunner();
        var token = new CancellationToken();
        runner.ExecIfNotCancelled(token, () => run = true);
        // Validate action has been executed
        Assert.AreEqual(true, run);
    }
    [TestMethod]
    public void TestActionRunnerDoesNotExecuteIfCancelled() {
        bool run = false;
        var runner = new ActionRunner();
        var token = new CancellationToken(true);
        try {
            runner.ExecIfNotCancelled(token, () => run = true);
            Assert.Fail("Exception not thrown");
        }
        catch (OperationCanceledException) {
            // Swallow only the expected exception
        }
        // Validate action hasn't been executed
        Assert.AreEqual(false, run);
    }
