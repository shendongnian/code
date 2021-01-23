    [Test]
    [ExpectedException(Handler = "HandleException")]
    public void ExampleTest()
    {
        var date = new DateTime(2014, 01, 14);
        throw new InvalidOperationException("Invalid date: " + date.ToString());
    }
    public void HandleException(Exception ex)
    {
        if (!(ex is InvalidOperationException))
            Assert.Fail("Invalid type of exception thrown by method");
        // Compare expected exception message with ex.Message
        // Assert.Fail if they do not match
    }
