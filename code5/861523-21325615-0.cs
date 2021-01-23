    [Test]
    public void TestThatHashOfHelloWorldIs98766()
    {
        Assert.AreEqual(98766, 
            Crc32.ComputeHash(System.Text.Encoding.Unicode.GetBytes("Hello World")));
    }
