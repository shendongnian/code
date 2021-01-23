    Console.WriteLine("Enter a number: ");
    int x = int.Parse(Console.ReadLine());
    double sum = 0;
    for (int i = 0; i < x; i++ )
    {
       Console.WriteLine("Ange tal {0}: ",i );
       double number = double.Parse(Console.ReadLine());
       sum += number;
    }
    
    Console.WriteLine("Sum of the entered numbers is: {0} ", sum);
    Console.ReadLine();
