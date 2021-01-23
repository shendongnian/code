    [Export(typeof(IMyMEFExample))]
    public class MyExportedMEFClass : IMyMEFExample
    {
    	public string HelloFromMEF()
    	{
    		return "Hello from MEF!";
    	}
    }
