    double sum = 0;
    for (int i = 0; i < x; i++ )
    {
        Console.WriteLine("Ange tal {0}: ",i );
        double numbers= double.Parse(Console.ReadLine());
        sum += numbers;
    }
        Console.WriteLine("Sum of the entered numbers are: {0} ",sum);
