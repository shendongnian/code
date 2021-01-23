    Random rand = new Random(); 
    int yes = 0;
    const int iterations = 10000000;
	for (int i = 0; i < iterations; i++)
	{
       if (rand.Next(1, 101) <= 25)
       {
           yes++;
       }
	}
	Console.WriteLine((float)yes/iterations);
