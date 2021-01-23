    public void insertFormat()
    {
    	Console.Clear();
    	Console.WriteLine(title);
    }
    
    while (suggestAgain != "n")
    {
    	insertFormat();
    
    	Console.WriteLine("For Breakfast may we suggest:" + bSelections[selectRandomArrayPosition(0, 4)] + "\n");
    	Console.WriteLine("Please enter \"N\" for a new selection, or any other key to exit \n");
    	
    	suggestAgain = Console.ReadLine().ToLower();
    }
