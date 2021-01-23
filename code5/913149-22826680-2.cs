    // this unit test is flaky
    [Test]
    public void TestGetLeapYearDaysData()
    {
     var expected = 100;
    
     // we don't know if this method will return 100 or 200.
     var actual = new Birthday().GetLeapYearDaysData();
    
     Assert.AreEqual(expected, actual);
    }
