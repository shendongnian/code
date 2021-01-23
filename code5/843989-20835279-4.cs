    [Test]
    public void GetsOnlyResultsContainingAwesome() {
       var fakeConfig = new FakeConfig();
       var awesome = new MyAwesomeClass(fakeConfig);
       IEnumerable<string> results = awesome.GetFiltered();
       Assert.AreEqual(2, results.Count());        
    }
