    [TestMethod]
    public void TestMethod1()
    {
        using(ShimsContext.Create()) {
            int counter = 0; // define the int outside of the delegate to capture it's value between calls.
            ShimFoo sfoo = new ShimFoo();
            sfoo.GetListString = (param) =>
            {
                List<Bar> result = null;
                switch (counter)
                {
                    case 0: // First call
                        result = new Bar[] { }.ToList();
                        break;
                    case 1: // Second call
                        result = new Bar[] { new Bar() }.ToList();
                        break;
                }
                counter++;
                return result;
            };
            Foo foo = sfoo.Instance;
            Assert.AreEqual(0, foo.GetList("first").Count(), "First");
            Assert.AreEqual(1, foo.GetList("second").Count(), "Second");
            Assert.IsNull(foo.GetList("third"), "Third");
        }
    }
