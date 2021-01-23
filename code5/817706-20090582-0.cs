    [Test]
    public void SerializerTest()
    {
        Dictionary<string, object> o = new Dictionary<string, object>();
        o.Add("k1", 23);
        o.Add("k2", 56);
    
        Assert.AreEqual("{\"k1\":23,\"k2\":56}", JsonSerializer.SerializeToString(o));
    }
