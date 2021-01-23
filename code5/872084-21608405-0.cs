    Random rnd = new Random();
    int sumOdd = 0;
    Console.WriteLine("\n20 random integers from 1 to 10:");
    for (int X = 1; X <= 20; X++)
    {
    	int y = rnd.Next(1, 10);
    	if (y % 2 == 1)
    	{
    	sumOdd += y;
    	//add all the odd # and display sum
    	// no clue lol
    	}
    	else
    	{
    	}
    	Console.WriteLine("{0}", y);
    }
    Console.WriteLine("Sum is {0}", sumOdd);
    Console.ReadLine();
