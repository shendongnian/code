    [TestCleanup()]
    public void MyTestCleanup()
    {
        switch (TestContext.CurrentTestOutcome)
        {
            case UnitTestOutcome.Passed:
                // Success.
                break;
            case UnitTestOutcome.Aborted:
            case UnitTestOutcome.Error:
            case UnitTestOutcome.Failed:
            case UnitTestOutcome.Inconclusive:
            case UnitTestOutcome.InProgress:
            case UnitTestOutcome.Timeout:
            case UnitTestOutcome.Unknown:
                // Oh dear.
                break;
            default:
                // Should never be called.
                break;
        }
    }
