        [TestMethod]
        public void It_Creates_Mock_For_A_Class()
        {
            var mock = new Mock<Activity>("Code 1", null, "Option");
            mock.CallBase = true;
            Assert.IsNotNull(mock.Object);
            Assert.AreEqual("Code 1", mock.Object.Code);
        }
