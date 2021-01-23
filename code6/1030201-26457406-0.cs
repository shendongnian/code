    [TestMethod]
    public void TestAddBook ()
    {
        Book id = new Book (new string[] {"ABC", "DEF"});
        id.AddBook ("GHI");
        Assert.AreEqual (true, id.Exist ("ghi"));
    }
     
