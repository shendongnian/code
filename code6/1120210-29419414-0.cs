    [TestMethod]
    public void TestMethod1()
    {
        var x = new GetFooQueryHandler(new TestFooRepository
            {
                Foo = new List<FooData>()
            });
        var result = x.Execute(new GetFooDataQuery { FooId = 45 });
    }
    class TestFooRepository : IFooRepository
    {
        public IEnumerable<FooData> Foo { get; set; }
    }
