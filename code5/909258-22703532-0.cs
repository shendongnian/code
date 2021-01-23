    [TestMethod()]
    public void TestIfReturnAnInstanceOfInterface()
    {
        Class1 class1 = new Class1();
        Assert.IsInstanceOfType(class1.returnAnInstanceOfInterface(),typeof(Class2));
    }
