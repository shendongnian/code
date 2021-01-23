    static void countValues()
    {
    
        float value1;
        float value2;
        float result;
        Console.WriteLine("Give a number");
        value1 = Convert.ToSingle(Console.ReadLine());
        Console.WriteLine("Give another number");
        value2 = Convert.ToSingle(Console.ReadLine());
    
        result = value1 + value2;
    
        Console.WriteLine("You gave numbers " + value1 + " and " + value2);
        Console.WriteLine("Together these values are " + result);
    
        Console.Read();
    }
