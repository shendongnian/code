    [Test]
    public void TestMatch()
    {
        var v = new Variant<int, string>();
       
        v.Set(10);
        var r1 = v.Match(
            i => i * 2,
            s => s.Length);
        Assert.AreEqual(20, r1);
        v.Set("test");
        var r2 = v.Match(
            i => i.ToString(),
            s => s + s);
        Assert.AreEqual("testtest", r2);
    }
