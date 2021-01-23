    public class UserServcieMockManager
    {
    	//mock objects here if you're using a mocking framework
    	public UserService GetServiceForTesting()
    	{
    		return new UserService(null); //here's where the mocks would be used
    	}
    }
