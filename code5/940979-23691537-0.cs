    var an_int = 4;
	var a_string = "poor poor marry";
	int[] an_array = new int[3] {1,2,3};
	
	if (an_int is IEnumerable)
		Console.WriteLine("you shouldn't see this");
	
	if (a_string is IEnumerable)
		Console.WriteLine("you should see this, as IEnumerable char");
		
	if (an_array is IEnumerable)
		Console.WriteLine("you should see this, as IEnumerable int");
