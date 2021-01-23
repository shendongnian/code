    [Test]
    public void ListTest()
    {
        var thing = new MyOtherClass();
        var expected = new List<MyClass>();
        expected.Add(thing);
        var actual = new List<MyClass>();
        actual.Add(thing);
        CollectionAssert.AreEqual(expected,actual);
    }
