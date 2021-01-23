        [Test]
        public void Context_SchemaIsExpected()
        {
            var summary = ModelSummary.Load(new MyContext());
            Assert.IsTrue(summary.EntityExists("Item"));
            Assert.IsTrue(summary.EntityHasProperty("Item", "Id"));
        }
