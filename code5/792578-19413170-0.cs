    const int STOP = 0;
    int input = -1;
    
    List<int> Out = new List<int>();
    
    while (input != STOP)
    {
        Console.WriteLine("Enter a number. You can end the program at anytime by entering 0");
        input = Convert.ToInt32(Console.ReadLine());
    
        if (input == STOP) break;
        
        Out.Add(input);
        
    }
    
    
    Console.WriteLine("Lowest number is {0}", Out.Min());
    Console.WriteLine("Highest number is {0}", Out.Max());
    Console.WriteLine("Average is {0}", Out.Average());
    Console.WriteLine("Count: {0}", Out.Count);
    Console.ReadLine();
