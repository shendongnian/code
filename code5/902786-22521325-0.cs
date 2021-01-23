    [Test]
    public void TestItemProperty()
    {
        var session = A.Fake<HttpSessionStateBase>();
        // tell the setter property to do what it normally would
        A.CallTo(session)
            .Where(call => call.Method.Name == "set_Item")
            .CallsBaseMethod();
    
        // most of the time the getter will do waht it normally would too
        A.CallTo(() => session[A<string>._]).CallsBaseMethod();
        // however, when the getter is called with key "key1", return "value1"
        A.CallTo(() => session["key1"]).Returns("value1");
    
        Assert.That(session["key1"], Is.EqualTo("value1"));
    
        session["key2"] = "value2";
        Assert.That(session["key2"], Is.EqualTo("value2"));
    
        Assert.That(session["key1"], Is.EqualTo("value1"), "second go");
    }
