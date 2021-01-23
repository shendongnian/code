    [TestMethod]
    public void TestMethod1()
    {
        using(ShimsContext.Create()) {
            ShimFoo sfoo = new ShimFoo();
            sfoo.GetListString = (param) =>
            {
                List<Bar> result = null;
                switch (param)
                {
                    case "first": // First call
                        result = new Bar[] { }.ToList();
                        break;
                    case "second": // Second call
                        result = new Bar[] { new Bar() }.ToList();
                        break;
                }
                return result;
            };
            Foo foo = sfoo.Instance;
            Assert.AreEqual(0, foo.GetList("first").Count(), "First");
            Assert.AreEqual(1, foo.GetList("second").Count(), "Second");
            Assert.IsNull(foo.GetList("third"), "Third");
        }
    }
