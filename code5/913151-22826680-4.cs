    public class Birthday
    {
     private IDateHelper _dateHelper;
    
     // any caller can inject their own version of dateHelper.
     public Birthday(IDateHelper dateHelper)
     {
      this._dateHelper = dateHelper;
     }
     
     public int GetLeapYearDaysData()
     {
       // some self-logic..
    
       // now call our injected helper's method.
       var isLeapYear = this._dateHelper.IsLeapYear();
    
       // based on this value, you might return 100 or 200.
    
       if (isLeapYear)
       {
        return 100;
       }
       
       return 200;
     }
    }
    
    // now see how are unit tests can be more robust and reliable
    
    // this unit test is more robust
    [Test]
    public void TestGetLeapYearDaysData()
    {
     var expected = 100;
    
     // use any mocking framework or stubbed class
     // to reliably tell the unit test that 100 needs to be returned.
    
     var mockDateHelper = new Mock<IDateHelper>();
   
     // make the mock helper return true for leap year check.
     // we're no longer at the mercy of current date time.
     
     mockDateHelper.Setup(m=>m.IsLeapYear()).Returns(true);
    
     // inject this mock DateHelper in our BirthDay class
     // we know for sure the value that'll be returned.
     var actual = new Birthday(mockDateHelper).GetLeapYearDaysData();
    
     Assert.AreEqual(expected, actual);
    }
