    public class sing
    {
    	public string singName {
    		get { return _singName; }
    		set { _singName = value; }
    	}
    
    	private string _singName;
    	public DateTime singStart {
    		get { return _singStart; }
    		set { _singStart = value; }
    	}
    
    	private DateTime _singStart;
    	public DateTime singEnd {
    		get { return _singEnd; }
    		set { _singEnd = value; }
    	}
    
    	private DateTime _singEnd;
    
    
    	public void findSing(System.DateTime usersDate)
    	{
    		List<sing> ListOfSings = new List<sing>();
    
    		sing scorpio = new sing();
    		System.DateTime startD = new System.DateTime(1910, 10, 23);
    		System.DateTime endD = new System.DateTime(1910, 11, 21);
    		scorpio.singName = "scorpio";
    		scorpio.singStart = startD;
    		scorpio.singEnd = endD;
    		ListOfSings.Add(scorpio);
    		//' ....etc all the others
    
    		dynamic q = (from i in ListOfSingswhere i.singStart >= usersDate && i.singEnd <= usersDatei).ToList;
    
    		MessageBox.Show("your sing is: " + q.FirstOrDefault.singName);
    
    	}
    }
