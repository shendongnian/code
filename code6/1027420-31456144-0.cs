    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestCaseSourceEx : TestCaseSourceAttribute
    {
    	public TestCaseSourceEx(Type sourceType, string sourceName, [CallerMemberName] string methodName = null)
    		: base(sourceType, sourceName)
    	{
    
    	}
    	public TestCaseSourceEx(string sourceName, [CallerMemberName] string methodName = null)
    		: base(sourceName)
    	{
    
    	}
    }
    
    [TestFixture]
    public class SampleTests
    {
    	public IEnumerable List = new[] { new string[] { "test-username", "test-password" } };
    
    	[Test, TestCaseSourceEx("List")]
    	public void SampleTests_LoginTest(string username, string password)
    	{
    		  
    	}
    }
 
