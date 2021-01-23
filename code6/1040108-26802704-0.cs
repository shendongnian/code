        [TestInitialize]
        public void Initialize()
        {
            Timer timer = new Timer(FailTheTest, null, 0, timeoutValue);            
        }
        private void FailTheTest(object state)
        {
            Assert.Fail("Insert here your timeout message");
        }
