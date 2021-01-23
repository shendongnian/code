       private const string ValidHtml = "<!DOCType html><html><head></head><body><p>Hello World</p></body></html>";
        private const string BrokenHtml = "<!DOCType html><html><head></head><body><p>Hello World</p></body>";
        [TestMethod]
        public void CanValidHtmlStringReturnNoErrors()
        {
            Validator subject = new Validator(ValidHtml);
            subject.ValidateHtmlFile();
            Assert.IsTrue(subject.HasExecuted);
            Assert.IsTrue(subject.Errors.Count == 0);
        }
        [TestMethod]
        public void CanInvalidHtmlStringReturnErrors()
        {
            Validator subject = new Validator(BrokenHtml);
            subject.ValidateHtmlFile();
            Assert.IsTrue(subject.HasExecuted);
            Assert.IsTrue(subject.Errors.Count > 0);
            Assert.IsTrue(subject.Errors[0].ToString().Contains("ERROR"));
        }
