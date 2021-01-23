    int choice;
    do
    {
        Console.WriteLine("1)Addition\n2)Subration\n3)Multiplication\n4)Division");
        choice = Convert.ToInt32(Console.ReadLine());
    }
    while (choice < 1 && 4 < choice);
