    [TestMethod]
    public void ShouldThrowExceptionIfArgumentIsOutOfRange()
    {
        try 
        {
            new Circle(-1);
            Assert.Fail("Constructor did not throw exception");
        }
        catch (ArgumentOutOfRangeException)
        {
            Assert.Pass();
        }
    }
