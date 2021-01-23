    [TestMethod]
    public void Integers_7Add1_equals8()
    {
       int expected = 8;
       int actual = MyClass.AddOne(7);
       Assert.AreEqual(expected, actual);
    }
