    static void Main(string[] args)
    {
    	List<int> ints = new List<int>();
                
    	//capture numbers from user input
    	while(true)
    	{
    		Console.WriteLine("Enter a number");
    		int number = Convert.ToInt32(Console.ReadLine());
    		
    		if (number == -1) //If user enters magic number, we break out of while loop
    			break;
    		
    		ints.Add(number); //Unless we've broken out, add the number to the list
    	}
    	
    	//do your bubble sort here
    	//this is up to you to implement!
    	
    	//print the results
    	foreach(int sortedNumber in ints)
    	{
    		Console.WriteLine(sortedNumber);
    	}
    }
