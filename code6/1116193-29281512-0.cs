    [TestMethod]
    public void MyMethod()
    {
        var a1 = new Thing();
        var a2 = new Thing();
        var a3 = new Thing();
        var list1 = new List<Thing> { a1, a2, a3 };
        var list2 = new List<Thing> { a1, a2, a3 };
        var list3 = new List<Thing> { a3, a2, a1 };
        list1.Should().ContainInOrder(list2); // Succeeds
        list1.Should().ContainInOrder(list3); // Fails
    }
