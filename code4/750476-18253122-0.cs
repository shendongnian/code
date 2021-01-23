    Console.WriteLine("Enter an number: ");
            int x = int.Parse(Console.ReadLine());
            ListMdouble> allNumbers = new List<double>();
            for (int i = 0; i < x; i++ )
            {
                Console.WriteLine("Ange tal {0}: ",i );
                allNumbers.Add( double.Parse(Console.ReadLine()));
    
            }
    
            Console.WriteLine("Sum of the entered numbers are: {0} ",allNumbers.Sum());
            Console.ReadLine();
