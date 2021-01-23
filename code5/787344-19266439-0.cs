        [TestMethod]
        public void ValidateGetName_VerifyGetNameMethodIsCalled()
        {
            //Arrange    
            var mock = new Mock<ICmdParseWrapper>();
            var sut = new CmdParserWrapper(mock.Object);
            //Act
            sut.ValidateGetName(It.IsAny<ServiceArgs>());
            //Assert
            mock.Verify(x => x.GetName(It.IsAny<ServiceArgs>()));
        }
