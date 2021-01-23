    for(;;)
    {
    	Console.WriteLine("Enter: Month Year NumberOfMonths\nPress enter to stop.");
    	string line = Console.ReadLine();
    	if (line == "")
    		break;
    	string[] terms = line.Split();
    	int
    		month = int.Parse(terms[0]),
    		year = int.Parse(terms[1]),
    		numberOfMonths = int.Parse(terms[2]);
    	for (int i = 0; i < numberOfMonths; i++)
    	{
    		GenMonth(month, year);
    		if (month == 12)
    		{
    			month = 1;
    			year++;
    		}
    		else
    			month++;
    	}
    }
    
    Console.Write("\nPress any key...");
    Console.ReadKey();
