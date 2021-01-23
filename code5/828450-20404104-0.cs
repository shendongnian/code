    [TestMethod]
    public void ForEach_Test()
    {
        //PREPARE
        List<string> listToBeTested = new List<string>();
        listToBeTested.Add("Any string");
        listToBeTested.Add("Any string");
        listToBeTested.Add("Any string");
        //EXECUTE
        List<string> listformatted = new List<string>();
        listToBeTested.ForEach(x => listformatted.Add(x));
        //ASSERT
        Assert.AreEqual(listToBeTested, listformatted);
    }
