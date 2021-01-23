    // Use the necessary namespace
    using NUnit.Framework;
 
    ...
    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Status == TestStatus.Failed)
        {
            // Your test failed, handle it
        }
    }
