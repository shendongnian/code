    static void Main(string[] args)
    {
        string name;
        string gender;
        Console.WriteLine("Welcome. What is your name?");
        name = Console.ReadLine();
        Console.WriteLine("Sex?\n-Male\n-Female");
        gender = Console.ReadLine();
        Console.WriteLine("Press Enter to continue");
        Console.ReadLine();
        Console.WriteLine("Welcome " + gender + name);
        Console.ReadLine();
    }
