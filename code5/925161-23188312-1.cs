    class FuncTest
    {
        public Func<int, string> DoStuff { get; set; }
        public string Value { get; set; }
    }
    [Test]
    public void Test_Func()
    {
        var test = new FuncTest();
        test.DoStuff = (num) => num.ToString();
        var deserialized = JsonConvert.DeserializeObject<FuncTest>(JsonConvert.SerializeObject(test));
        deserialized.Value = deserialized.DoStuff(5);
        Assert.That(deserialized.Value == "5");
    }
