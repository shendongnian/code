    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual("Hoon Group", Program.GetName(15));
        Assert.AreEqual("Hoon", Program.GetName(3));
        Assert.AreEqual("Group", Program.GetName(5));
        // test other values here
    }
