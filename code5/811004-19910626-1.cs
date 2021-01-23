        [Test]
        public void IsAdmin_CalledByAdminUser_ReturnTrue()
        {
            //Arrange
            var principalMock = new Mock<IPrincipal>();
            principalMock.Setup(x => x.IsInRole("admin")).Returns(true);
            //Act
            var userService = ...// create an instance of userService here
            var result = userService.IsAdmin(principalMock);
            //Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void IsAdmin_CalledByNonAdminUser_ReturnFalse()
        {
            //Arrange
            var principalMock = new Mock<IPrincipal>();
            principalMock.Setup(x => x.IsInRole("admin")).Returns(false);
            //Act
            var userService = ...// create an instance of userService here
            var result = userService.IsAdmin(principalMock);
            //Assert
            Assert.IsFalse(result);
        }
