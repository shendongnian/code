    [Test]
    public void MyTest()
    {
        short myValue = Convert.ToSByte("FF", 16);
        Assert.AreEqual(-1, myValue);
    }
