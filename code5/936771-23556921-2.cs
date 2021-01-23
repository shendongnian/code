    public static dynamic GetInput()
    {
        //declared variables
        dynamic userinputs;
     
        Console.Write("Enter your name: ");
        var _name = Console.ReadLine();
    
        Console.Write("Enter your age: ");
        var _age  = Console.ReadLine();
    
        Console.Write("Enter the Gas Mileage: ");
        vae _mileage = Console.ReadLine();
    
        userinputs.name = _name;
        userinputs.age = _age;
        userinputs.mileage = _mileage;
        
        return userinputs;
    }
