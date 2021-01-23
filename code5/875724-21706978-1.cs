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
            DateTime now = DateTime.Now;
            DateTime end = now.AddSeconds(5);
            while (now < end)
            {
                Console.WriteLine("Graduation!!!");
                now = DateTime.Now;                // <---- this line is the key
            }
        }
        Console.WriteLine(i);
        Console.ReadKey();
    }
