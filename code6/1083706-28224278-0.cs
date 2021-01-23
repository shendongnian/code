    public class PlayerRetriever
    {
    	public static IPlayer Retrieve(string SitePath)
    	{
    		if (SitePath == "Home") { return new Player1(); }
    		else { return new AnotherPlayer(); }
    	}
    }
