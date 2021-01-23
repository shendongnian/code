    void Main()
    {
    	List<Person> a = new List<Person>()
    	{
    		new Person { ID = 1 },
    		new Person { ID = 2 },
    		new Person { ID = 3 },
    	};
    	
    	List<Person> b = new List<Person>()
    	{
    		new Person { ID = 1 },
    	};
    	
    	var c = a.Where(x => b.Any(bprime => bprime.ID != x.ID));
    	foreach(var item in c)
        {
    		Console.WriteLine(item.ID);
        }
    }
    
    class Person
    {
    	public int ID { get; set; }
    }
