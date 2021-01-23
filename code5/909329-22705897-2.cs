    Dictionary<int, string> dictionary = new Dictionary<int, string>();
		dictionary.Add(04634, "AMBASAMUDRAM");
		dictionary.Add(04253, "ANAMALI");
		dictionary.Add(04153, "ARAKANDANALLUR");
	var value = dictionary.FirstOrDefault(x=>x.Key.Contains(04634)).Value; 
    Console.WriteLine(value);
