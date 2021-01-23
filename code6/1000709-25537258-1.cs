    [Test]
    public void CollectionContains()
    {
        var expected = new List<int> { 0, 1, 2, 3, 5 };
        var actual = 5;
    
        CollectionAssert.Contains(expected, actual);
        Assert.That(expected, Contains.Item(actual));
    }
