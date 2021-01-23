	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class WcfServiceTest : IContract
	{
	    static int _counter;
	    public WcfServiceTest()
	    {
	    	_counter++;
	    }
	    public string GetData(string p1)
	    {
	        return Convert.ToString(_counter);
	    }
	}
