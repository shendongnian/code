    int corectinteger;
    int input = Console.ReadLine();
    bool flag = true;
    while (flag)
    {
        if (input != corectinteger)
        {
            Console.WriteLine("Bad integer");
            input = Console.ReadLine();
        }
        else if (input == corectinteger)
            flag = false;
    }
