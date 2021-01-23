        [TestMethod]
        public void MyCellExampleTest()
        {
            var target = new MyCell();
            var targetPrivateObject = new PrivateObject(target);
            var result = targetPrivateObject.Invoke("MyCustomFormatting", new object[] { "Test" });
            Assert.AreEqual(string.Empty, result);
        }
