    public void TestMethod1()
    {
        //Mock of the foo class
        var t = new Mock<foo>(MockBehavior.Strict);
        //Setup to return what we want 0 instead of 1
        t.Setup(e => e.bar(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>()))
                      .Returns((int i, string s, bool b) => { return 0; });
        //the actual object
        var f = t.Object;
        //the actual test
        Assert.AreEqual(0, f.bar(1, "s", false));
    }
