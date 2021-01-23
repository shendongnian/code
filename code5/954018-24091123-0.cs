    [TestMethod]
    public void TestNullComposite()
    {
        IApi api = new Api();
        bool didThrow = false;
        try
        {
            api.GetDataUsingDataContract(null); // this method throws ArgumentNullException
        }
        catch(ArgumentNullException) 
        {
            didThrow = true;
        }
        Assert.IsTrue(didThrow);
    }
