     [TestMethod]
     public void GetHolidayEntitlement_WithBase25_Returns25()
     {
        //Arrange
        var user = new Mock<IUser>();
        //setup known, controlled property values on the mock:
        user.SetupGet(u=>u.BaseHolidayEntitlement).Returns(25);
        user.SetupGet(u=>u.EmploymentStartDate).Returns(new DateTime(2013,1,1));
        var sut = new UserRules();
        int expected = 25;
        //Act
        int actual = sut.GetHolidayEntitlement(user.Object);
        //Assert
        Assert.AreEqual(expected,actual,"GetHolidayEntitlement isn't working right...");
     }
