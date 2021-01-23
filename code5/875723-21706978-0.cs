    DateTime start = DateTime.Now.AddSeconds(0);
    DateTime end = DateTime.Now.AddSeconds(5);
    for (int i = 1988; i < 2020; i += 2)
    {
        if (i == 2000)
        {
            Console.WriteLine("New Mellenium");
            continue;
        }
        if (i == 2006)
        {
            Console.WriteLine("Age of Majority");
            continue;
        }
        if (i == 2014)
        {
            while (start < end)
            {
                Console.WriteLine("Graduation!!!");
                start = DateTime.Now;                // <---- this line is the key
            }
        }
        Console.WriteLine(i);
        Console.ReadKey();
    }
