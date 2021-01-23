        [Test]
        public void TestMock()
        {
            var a = new Mock<IDictionary<string, string>>();
            a.Setup(d => d[It.IsAny<string>()]).Returns((string input) => input + input);
            string result = a.Object["test"];
        }
