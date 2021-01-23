    Console.Write("Enter an number: ");
    int x = int.Parse(Console.ReadLine());
    double sum = 0;
    for (int i = 0; i < x; i++)
    {
        Console.Write("Ange tal {0}: ", i);
        double number = double.Parse(Console.ReadLine());
        sum = sum + number;
    }
    Console.WriteLine("Sum of the entered numbers are: {0:R} ", sum);
    Console.Write("Press a key to exit");
    Console.ReadKey();
