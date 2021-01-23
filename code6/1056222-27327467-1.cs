    [TestMethod]
    public void SortedSetTest()
    {
        var first = new Foo("Doe");
        var second = new Foo("Floyd");
        var third = new Foo("Floyd");
        var set = new SortedSet<Foo>(new BySomething());
        set.Add(first);
        set.Add(second);
        set.Add(third);
        Assert.AreEqual(set.Count, 2);
    }
