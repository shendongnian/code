    [Test]
    public void TestItemProperty()
    {
        var mySession = new Dictionary<string, object>();
        var session = A.Fake<HttpSessionStateBase>();
        A.CallTo(session)
            .Where(call => call.Method.Name == "set_Item")
            .Invokes((string key, object value) => mySession[key] = value);
        A.CallTo(() => session[A<string>._])
            .ReturnsLazily((string key) => mySession[key]);
        A.CallTo(() => session["key1"]).Returns("value1");
        A.CallTo(() => session["key1"]).Returns("value1");
        Assert.That(session["key1"], Is.EqualTo("value1"));
        session["key2"] = "value2";
        Assert.That(session["key2"], Is.EqualTo("value2"));
        Assert.That(session["key1"], Is.EqualTo("value1"), "second go");
    }
