    [Test]
    public void TestShouldPass()
    {
        var person1 = new Person { Name = "John" };
        var person2 = new Person { Name = "John" };
        var person3 = new Person { Name = "John" };
        AssertEx.AllAreEqual(person1.Name, person2.Name, person3.Name);
    }
    [Test]
    public void TestShouldFail()
    {
        var person1 = new Person { Name = "John" };
        var person2 = new Person { Name = "Bob" };
        var person3 = new Person { Name = "John" };
        AssertEx.AllAreEqual(person1.Name, person2.Name, person3.Name);
    }
