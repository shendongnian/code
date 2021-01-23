	Dictionary<int, parent> dictionary = new Dictionary<int, parent>();
	child child1 = new child();
	child child2 = new child();
	
	child1.age = 5;
	child2.age = 10;
	
	dictionary.Add(1,child1);
	dictionary.Add(2,child2);
	dictionary.Add(45, new parent());
	
	foreach(var c in dictionary.Select(x => x.Value).OfType<child>())
	{
		Console.WriteLine(c.age);
	}
