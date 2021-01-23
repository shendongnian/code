        Console.Write("Enter N number: ");
        double numberN = double.Parse(Console.ReadLine());
        double sum = 0;
        for (double i = 0; i < numberN; i++)
        {
            Console.Write("Enter number: ");
            double number = double.Parse(Console.ReadLine());
            sum += number;
        }
        Console.WriteLine("The sum is: {0}", sum); 
