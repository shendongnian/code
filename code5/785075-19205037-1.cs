	    [Test]
        public void CheckAndDo_WhenPassesCheckTrue_DoCalledOnlyOnceAndThrowsCheckDidNotPassException()
        {
            var checker = new Mock<IChecker>();
            var doer = new Mock<IDoer>();
            checker.Setup(x => x.PassesCheck).Returns(true);
            var sut = new ThingThatChecksAndDoes(checker.Object, doer.Object);
           
            Assert.Throws<CheckDidNotPassException>(() => { sut.CheckAndDo(); });
            doer.Verify(x => x.Do(), Times.Once());
        }
