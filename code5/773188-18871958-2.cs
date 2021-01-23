    [TestMethod]
    public void In()
    {
    
        IEnumerable<int> search = 0;
        IEnumerable<int> found = new int[] { 0, 0, 1, 2, 3 };
        IEnumerable<int> notFound = new int[] { 1, 5, 6, 7, 8 };
    
        Assert.IsTrue(search.In(found));
        Assert.IsFalse(search.In(notFound));
    }
