    [Test]
    public void SerializerTest()
    {
        Dictionary<string, object> o = new Dictionary<string, object>();
        o.Add("k1", "0123");
        o.Add("k2", "123.");
        Assert.AreEqual("{\"k1\":\"0123\",\"k2\":\"123.\"}", 
                        JsonSerializer.SerializeToString(o));
    }
