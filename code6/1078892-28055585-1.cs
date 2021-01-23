    void Main()
    {
    	List<ProgramA> progs = new List<ProgramA>{
    		new ProgramA("Summary", 1, 147),
    		new ProgramA("Software Functionality", -9, 211)
    		};
    	
    	int value= progs.OrderByDescending(a => a.Order).ThenBy(a => a.Name).ToList().First().ID;
    	
    	value.Dump();
    
    }
    
    // Define other methods and classes here
    class ProgramA
    {
    	private string sName = string.Empty;
    	private int iOrder = 0;
    	private int iID = 0;
    	
    	public ProgramA(string _Name, int _Order, int _ID)
    	{
    		sName = _Name;
    		iOrder = _Order;
    		iID = _ID;
    	}
    	
    	public string Name
    	{
    		get {return sName;}
    		set {sName = value;}
    	}
    	
    	public int Order
    	{
    		get {return iOrder;}
    		set {iOrder = value;}
    	}
    	
    	public int ID
    	{
    		get {return iID;}
    		set {iID = value;}
    	}
    }
