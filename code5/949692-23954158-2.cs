    public static void Main()
    {
    	List<Object> items = new List<Object>();
    	items.Add("test1");
    	items.Add("test2");
    	items.Add("test3");
	
	foreach(var a in items)
		Console.WriteLine(a.ToString());
	Console.WriteLine("--");
	items.RemoveAt(1); // remove object at position 1, in this case "test2"
			
	foreach(var a in items)
		Console.WriteLine(a.ToString());
	Console.WriteLine("--");
	
	items.RemoveAll(x => ((string) x) == "test1"); // LAMBDA query to remove by a condition
	
	foreach(var a in items)
		Console.WriteLine(a.ToString());
    }
