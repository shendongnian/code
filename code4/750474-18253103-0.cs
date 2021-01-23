    Console.WriteLine("Enter an number: ");
            int x = int.Parse(Console.ReadLine());
            double sum = 0
            for (int i = 0; i < x; i++ )
            {
                Console.WriteLine("Ange tal {0}: ",i );
                sum = sum + double.Parse(Console.ReadLine());
    
            }
    
            Console.WriteLine("Sum of the entered numbers are: {0} ",sum);
            Console.ReadLine();
