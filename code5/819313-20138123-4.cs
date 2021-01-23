        [TestMethod]
        public void IfSumIsUnder100ItShouldBeBumpedToIt()
        {
            double[] input = new []
                {
                    0.044,
                    0.664,
                    0.294
                };
            var result = input.SplitIntoPercentage();
            Assert.AreEqual(100, result.Sum());
            Assert.AreEqual(4, result[0]);
            Assert.AreEqual(66, result[1]);
            Assert.AreEqual(30, result[2]);
        }
        [TestMethod]
        public void IfSumIsOver100ItShouldBeReducedToIt()
        {
            double[] input = new[]
                {
                    0.045,
                    0.665,
                    0.295
                };
            var result = input.SplitIntoPercentage();
            Assert.AreEqual(100, result.Sum());
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(67, result[1]);
            Assert.AreEqual(28, result[2]);
        }
