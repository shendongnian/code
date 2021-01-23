    void Main()
    {
    	string name, age, mileage;
    	
    	GetInput(out name, out age, out mileage);
    	
    	//use name, age and mileage here.
    }
    public static void GetInput(out string pName, out string pAge, out string pMileage)
    {
        Console.Write("Enter your name: ");
        pName = Console.ReadLine();
        Console.Write("Enter your age: ");
        pAge = Console.ReadLine();
        Console.Write("Enter the Gas Mileage: ");
        pMileage = Console.ReadLine();
    }
