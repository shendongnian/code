    // simple attribute to mark functions as commands
    class CommandAttribute : Attribute
    {
    	public string Name {get;private set;}
    	public string[] Keys {get;private set;}
    	public int Rank {get;private set;}
    
    	public CommandAttribute(string name, int rank, params string[] keys)
    	{
    		Name = name;
    		Keys = keys;
    		Rank = rank;
    	}
    }
    // example commands
    [Command("Guild", 15, "g", "guild", "group")]
    public static void Guild(Player player,string[] args)
    {
    	// do stuff
    }
    [Command("Something other", 5, "f", "foo", "foobar")]
    public static void FooIt(Player player,string[] args)
    {
    	// do stuff
    }
