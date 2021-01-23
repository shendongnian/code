        [SetUp]
        protected virtual void SetUp()
        {
            FixtureHandle.Wait();
        }
        [TearDown]
        protected virtual void TearDown()
        {
            FixtureHandle.Set();
        }
