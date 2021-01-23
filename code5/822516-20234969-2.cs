    [Serializable]
    public class Sample : MarshalByRefObject
    {
    	public void DebugPrint()
    	{
    		Console.WriteLine("=====================================");
    		Console.WriteLine(ConfigurationManager.AppSettings.Count);
    		Console.WriteLine("Reading config: =====|{0}|=====", ConfigurationManager.AppSettings["MyData"]);
    		Console.WriteLine("=====================================");
    	}
    }
