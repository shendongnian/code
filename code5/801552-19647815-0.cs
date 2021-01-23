	var list = new HashSet<string>();
	list.Add("Dog");
	list.Add("Cat");
	list.Add("Bird");
	
	var list2 = new HashSet<string>();
	list.Add("Dog");
	list.Add("Cat");
	
	if (list2.IsSubsetOf(list))
	{
	      Console.Write("All items in list2 are in list1");
	}  
