    private const string test = "HellohelloHihiHeyhey";
    
    static void Main(string[] args)
    {
        string UserInput = Console.ReadLine();
        if (test.Contains(UserInput))
        {
            Console.WriteLine("success!!");
        }   
    }
