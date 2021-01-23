    [Test]
    public void Reset()
    {
        const string random = "this is a test string";
        using(var reader = new StringReader(random))
        {
            Assert.AreEqual(random, reader.ReadToEnd());
            Assert.IsEmpty(reader.ReadToEnd());
            reader.Reset();
            Assert.AreEqual(random, reader.ReadToEnd());
            Assert.IsEmpty(reader.ReadToEnd());
        }
    }
