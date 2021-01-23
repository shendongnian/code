    Dictionary<string, int> wrongs;
    //Console questions...
    //Begin looping logic
    wrongs = new Dictionary<string, int>();
    for (int i = 1; i <= numberOfGos; i++)
    {
        randomNumberTables = rng.Next(minRangeTables, maxRangeTables + 1);
        randomNumber = rng.Next(minRange, maxRange + 1);
        string eq = String.Format("{0} x {1} = ", randomNumberTables, randomNumber);
        Console.Write("{0}: " + eq, i);
        if (randomNumberTables * randomNumber == int.Parse(Console.ReadLine()))
        {
            Console.WriteLine("Correct");
            c++;
        }
        else
        {
            Console.WriteLine("Wrong it is: " + randomNumberTables * randomNumber);
            if (wrongs.Any(x => x.Key == eq))
            {
                wrongs[eq]++;
            }
            else
            {
                wrongs.Add(eq, 1);
            }
            w++;
        }
    }
    Console.WriteLine("\nYou were correct {0} times, and wrong {1} times.", c, w);
    Console.WriteLine("\n\nYou got:");
    foreach (var item in wrongs)
    {
        Console.WriteLine("{0} wrong {1} times", item.Key, item.Value);
    }
    //Your logic to repeat/restart
