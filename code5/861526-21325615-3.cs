    [Test]
    public void TestNullThrows()
    {
        Assert.Throws<ArgumentNullException>(() => Crc32.ComputeHash(null));
    }
