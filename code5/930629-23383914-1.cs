        [TestMethod]
        public void TestNestedConstructionWithIdentifier()
        {
            using (var container = new UnityContainer())
            {
                string identifier = Guid.NewGuid().ToString();
                container.RegisterType<Abstract, Bar>(identifier);
                container.RegisterType<IFoo, Foo>(identifier, new InjectionConstructor(new ResolvedParameter<Abstract>(identifier)));
                var foo = container.Resolve<IFoo>(identifier);
                Assert.AreEqual("Bar", foo.GetTypeOfInnerClass().Name);
            }
        }
