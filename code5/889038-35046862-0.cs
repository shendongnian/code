    public class TestClass {
    	bool isSaturday(DateTime dt)
    	{
    	   string day = dt.DayOfWeek.ToString();
    	   return (day == "Saturday");
    	}
    	 
    	[Theory]
    	[MemberData("IsSaturdayIndex", MemberType = typeof(TestCase))]
    	public void test(int i)
    	{
    	   // parse test case
    	   var input = TestCase.IsSaturdayTestCase[i];
    	   DateTime dt = (DateTime)input[0];
    	   bool expected = (bool)input[1];
    	 
    	   // test
    	   bool result = isSaturday(dt);
    	   result.Should().Be(expected);
    	}	
    }
