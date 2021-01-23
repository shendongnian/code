    void Main()
    {
    	A();
    }
    
    public void A()
    {
    	List<Action> list = new List<Action>();
    	list.Add(B);
    	list.Add(C);
    	list.Add(D);
    	
    	foreach(Action action in list){
    		action();
    	}
    }
    
    
    public void B()
    {
        Console.WriteLine("B Called");
    }
    
    
    public void C()
    {
    	Console.WriteLine("C Called");
    }
    
    
    public void D()
    {
    	Console.WriteLine("D Called");
    }
