    class MLB_Games : IGames
    {
    	public string Name { get; set; }
    }
    class NCAAF_Games : IGames
    {
    	public string Name { get; set; }
    }
    class NFL_Games : IGames
    {
    	public string Name { get; set; }
    }
    interface IGames
    {
    	string Name { get; set; }
    }
