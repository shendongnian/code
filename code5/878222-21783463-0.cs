    int exit = 1;
    do
    {
        Console.WriteLine("would you like to print results? 0-no 1-yes");
        exit = int.Parse(Console.ReadLine());
        if (1 == exit)
        {
            int rangeHigh;
            int rangeLow;
            bool high = int.TryParse(Console.ReadLine(), out rangeHigh);
            bool low = int.TryParse(Console.ReadLine(), out rangeLow);
            if (high == true && low == true)
            {
                for (int i = rangeLow; i < rangeHigh; i++)
                {
                    //Console.WriteLine( i + ". " + array[i]);
                }
            }
        }
    }
    while (exit != 0);
