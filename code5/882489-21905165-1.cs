    [TestMethod]
    public void ThreadExceptionTest()
    {
        new Thread(() => { throw new Exception("Error in thread"); }).Start();
    }
