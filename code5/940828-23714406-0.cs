    [TestMethod]
    public void Test2()
    {
        NamerFactory.AdditionalInformation = this.GetType().Name;
        Approvals.Verify(2);
    }
