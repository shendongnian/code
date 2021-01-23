    [TestMethod]
    public void WeekTest()
    {
         //Arrange
         Period weekPeriod = new Period(new DateTime(2014, 5, 5), TimeSpan.FromDays(7));
         //Act
         bool isweek = weekPeriod.IsFullWeek;
         //Assert
         Assert.IsTrue(isweek );
    }
