    [TestMethod]
    public void tenNotEqualten()
    {
      Int32 a = 10;
      UInt64 b = 10;
      Assert.AreEqual(Convert.ToUInt64(a), b);
    }
