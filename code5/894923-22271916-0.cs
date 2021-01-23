    void Main()
    {
    	Console.WriteLine("Please enter some numbers seperated by a space");
    	Console.WriteLine("");
    	
    	var userInput = Console.ReadLine();
    	var numbers = userInput.Split(' ');
    	
    	var lowestNumbers = numbers.Where(n => int.Parse(n) > -1).OrderBy(n => int.Parse(n)).Take(4).ToList();
    	lowestNumbers.ForEach(n => Console.Write(n));
    }
