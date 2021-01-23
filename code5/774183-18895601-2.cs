    //LINQPAD SNIPPET
    void Main()
    {
    	List<WorkStatus> list = new List<WorkStatus>();
    	
    	list.Add(new SecondStatus()); //out of order initially.
    	list.Add(new FirstStatus());
    	
    	Console.WriteLine(list.OrderBy(x => x));
    	
    	
    }
