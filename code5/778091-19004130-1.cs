    [TestMethod]
    public void Can_Add_Two_Numbers() {
        var math = new MathClass();
        var result = math.Add(1, 2);
        Assert.AreEqual(3, result);
    }
