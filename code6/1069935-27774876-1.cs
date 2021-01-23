    void Main()
    {
    
    	List<MyData> data = new List<MyData>{
    					new MyData(1,10),
    					new MyData(2, 11),
    					new MyData(5, 12),
    					new MyData(8, 13),
    					new MyData(12, 14)
    					};
    	//you're using comma delimited string 
    	//string searchedNumbers = "1,3,4,5";
    	//var qry = from n in data 
    	//		join s in searchedNumbers.Split(',').Select(x=>int.Parse(x)) on n.ID equals s 
    	//		select n;
    	//qry.Dump();
        List<int> searchedNumbers = new List<int>{1,2,4,5};
    	var qry = from n in data 
    			join s in searchedNumbers on n.ID equals s 
    			select n;
    	qry.Dump();
    }
    
    // Define other methods and classes here
    class MyData
    {
    	private int id = 0;
    	private int weight = 0;
    	
    	public MyData(int _id, int _weight)
    	{
    		id = _id;
    		weight = _weight;
    	}
    	
    	public int ID
    	{
    		get{return id;}
    		set {id = value;}
    	}
    
    	public int Weight
    	{
    		get{return weight;}
    		set {weight = value;}
    	}
    }
