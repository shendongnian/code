    [TestMethod]
    public void In()
    {
    
        IEnumerable<int> search = new int[] { 0 };
        IEnumerable<int> a = new int[] { 0, 0, 1, 2, 3 };
        IEnumerable<int> b = new int[] { 0, 0, 1, 2, 3 };
        IEnumerable<int> c = new int[] { 0};
    
        Assert.IsTrue(search.In(a,b,c));
        Assert.IsFalse(search.In(a,b));
    }
