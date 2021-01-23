	List<int> a = new List<int>();
	a.Add(1);
	
	Console.WriteLine(a.Count); //1
	
	List<int> b = a;
	b.Add(2);
	
	Console.WriteLine(b.Count); //2
	Console.WriteLine(a.Count); //2
	Console.WriteLine(Object.ReferenceEquals(a, b)); //true
