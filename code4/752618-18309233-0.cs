    [Test]
    public void tst()
    {
        var filterMe = "foo=1;bar=foo+5;foobar=foo+5-bar;";
        var dic = filterMe.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                          .ToDictionary(x => x.Split('=')[0], x => x.Split('=')[1]);
        while (true)
        {
            var kvpToApply = dic.Keys
                                .Join(dic, x => true, y => true, (key, value) => new { key, value })
                                .FirstOrDefault(x => x.value.Value.Contains(x.key));
            if (kvpToApply != null)
            {
                dic[kvpToApply.value.Key] = kvpToApply.value.Value.Replace(kvpToApply.key, dic[kvpToApply.key]);
            }
            else
            {
                break;
            }
        }
        Assert.AreEqual("1", dic["foo"]);
        Assert.AreEqual("1+5", dic["bar"]);
        Assert.AreEqual("1+5-1+5", dic["foobar"]);
    }
