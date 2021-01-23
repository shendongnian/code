    var config = new ParsingConfig
    {
         CustomTypeProvider = new TestCustomTypeProvider()
    };
    var q = b.AsQueryable().Select(config, "A.Test(it.Item1)");
