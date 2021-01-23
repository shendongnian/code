    void Main()
    {
    	var list = new List<CustomObject>() 
    	{
    		new CustomObject() {Id = 1, Month ="May", Commodity ="Wheat", Amount = 100},
    		new CustomObject() {Id = 2, Month ="May", Commodity ="Rice", Amount = 200},
    		new CustomObject() {Id = 3, Month ="June", Commodity ="Wheat", Amount = 400},
    		new CustomObject() {Id = 4, Month ="July", Commodity ="Maize", Amount = 100},
    		new CustomObject() {Id = 5, Month ="August", Commodity ="Raspberry", Amount = 666},
    	};
    	
    	var result = list.GroupBy (l => l.Month)
    					 .Select (l => new {
    					 	Month = l.Key,
    						Wheat = l.Where(x => x.Commodity == "Wheat").Sum (x => x.Amount),
    						Rice = l.Where(x => x.Commodity == "Rice").Sum (x => x.Amount),
    						Maize = l.Where(x => x.Commodity == "Maize").Sum (x => x.Amount),
    						Raspberry = l.Where(x => x.Commodity == "Raspberry").Sum (x => x.Amount),
    					 });
    					 
    	result.Dump();
    }
    
    // Define other methods and classes here
    class CustomObject
    {
    	public int Id { get; set; }
    	public string Month { get; set; }
    	public string Commodity { get; set; }
    	public int Amount { get; set; }
    }
