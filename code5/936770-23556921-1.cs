    public static object GetInput()
    {
        Console.Write("Enter your name: ");
        var _name = Console.ReadLine();
    
        Console.Write("Enter your age: ");
        var _age  = Console.ReadLine();
    
        Console.Write("Enter the Gas Mileage: ");
        vae _mileage = Console.ReadLine();
    
        return new { name = _name, age = _age, mileage = _mileage };
    }
