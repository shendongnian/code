    void Main()
    {
    	var people = new List<IPerson>();
    	people.Add(new American { Name = "jack"});
    	people.Add(new American { Name = "John"});
    	people.Add(new Asian { Name = "ho"});
    	
    	Console.WriteLine (people.OfType<American>());
    	
    }
    
    public interface IPerson {
    	string Name {get; set;}
    }
    
    class American : IPerson {public string Name {get; set; }}
    class Asian : IPerson {public string Name {get; set; }}
    class European : IPerson {public string Name {get; set; }}
