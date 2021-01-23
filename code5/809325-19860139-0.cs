    Console.WriteLine("Please write a Number: ");
    Console.Write("Number: ");
    int num = int.Parse(Console.ReadLine());
    for (int i = 0; i <= num; i++)
    {
        for (int j = num - i; j >= 0; j--)
        {
            Console.Write(j);
        }
        for (int j = num; j > num - i; j--)
        {
            Console.Write(j);
        }
        Console.WriteLine();
    }
    Console.ReadLine();
