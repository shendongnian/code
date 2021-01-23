    Console.WriteLine("Enter an number: ");
    int x = int.Parse(Console.ReadLine());
    List<double> allNumbers = new List<double>();
    for (int i = 0; i < x; i++ )
    {
          Console.WriteLine("Ange tal {0}: ",i );
          double temp;
          if(double.TryParse(Console.ReadLine(), out temp))
             allNumbers.Add(temp);
          else
              Console.WriteLine("Enter a valid number");  
    }
    
    Console.WriteLine("Sum of the entered numbers are: {0} ",allNumbers.Sum());
    Console.ReadLine();
