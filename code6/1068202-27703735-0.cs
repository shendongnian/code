    Console.Write("Enter age of "+j+" guest : ");
    age = Convert.ToInt32(Console.ReadLine());
    int tries = 0;
    while (age < 0)
    {
        if (tries >= MAX_TRIES)
           return;
        else
           ++tries;
        Console.WriteLine("Age must be zero or a positive number");
        age = Convert.ToInt32(Console.ReadLine());
    }
