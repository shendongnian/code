    var numbers = new List<int>();
    
    foreach (string s in Console.ReadLine().Split())
    {
    	if (int.TryParse(s, out int number))
    		numbers.Add(number);
    	else
    		Console.WriteLine($"{s} is not an integer");
    }
