        [TestMethod]
        public void TestGetFileShareAccessInstance()
        {
            var first = FileShareAccessFactory.GetFileShareAccessInstance(contextFactory, logger);
            var second = FileShareAccessFactory.GetFileShareAccessInstance(contextFactory, logger);
            
            Assert.IsTrue(object.ReferenceEquals(first, second));
        }
