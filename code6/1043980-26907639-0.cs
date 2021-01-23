    internal class ProcessedLine
    {
    	public string Original {get; private set;}
    	public List<string> Trimmed {get; private set;}
    	
    	public ProcessedLine(string original)
    	{
    		Original = original;
    		Trimmed = original.Select(x => x.Split(';')).Select(x => x.Trim()).ToList();
    	}
    	
    	public string SortKey1
    	{
    		get{ return Trimmed[4]; }
    	}
    	
    	public string SortKey2
    	{
    		get{ return Trimmed[1]; }
    	}
    }
