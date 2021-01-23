    void Main()
    {
    	List<Thing> things = new List<Thing>();
    	things.Add(new Thing(){
    		Name = "test"
    	});
    	
    	string testString = "te st";
    	
    	var result = things.Where (x => x.Name == testString.Replace(" ", String.Empty)).FirstOrDefault();
    	
    	Console.WriteLine(result.Name);
    }
    
    class Thing
    {
    	public string Name {get;set;}
    }
