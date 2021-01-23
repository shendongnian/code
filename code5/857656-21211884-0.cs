    bool validInput = false;
    while (!validInput )
    {
        Console.WriteLine("Please choose a Drink; Press 1 for Coke, Press 2 for Sprite, Press 3 for Dr.Prpper");
        int_bvg_type = int.Parse(Console.ReadLine());
        if ((int_bvg_type > 0) && (int_bvg_type < 4))
            validInput = true;
        else
            Console.WriteLine("PLease enter a Number between 1 and 3");
    }
