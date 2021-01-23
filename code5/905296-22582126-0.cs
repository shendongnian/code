    void Main()
    {
    	var sales = new List<Sale>()
    	{
    		new Sale() {Id = 1, Sales1 = 25, Sales2= 15, Sales3= 15},
    		new Sale() {Id = 1, Sales1 = 10, Sales2= 7, Sales3= 3},
    		new Sale() {Id = 2, Sales1 = 8, Sales2= 11, Sales3= 9},
    		new Sale() {Id = 3, Sales1 = 10, Sales2= 5, Sales3= 7},
    		new Sale() {Id = 3, Sales1 = 22, Sales2= 9, Sales3= 4},
    	};
    	
    	var filteredSales = sales.GroupBy (s => s.Id)
    							 //.Where (s => s.Key == 1)
    							 .Select (s => new 
    							  {
    							   Id = s.Key,
    							   Sum = s.Sum (x => x.Sales1 + x.Sales2 + x.Sales3) 
    							  }).Dump();
    }
    
    class Sale
    {
    	public int Id { get; set; }
    	public int Sales1 { get; set; }
    	public int Sales2 { get; set; }
    	public int Sales3 { get; set; }
    }
