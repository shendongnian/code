    string decision ;
    do
    {
        string name = GetName();
        Console.WriteLine("Would you like to input another name? Yes - No");
        decision = Console.ReadLine();
    }while(decision.ToUpper().StartsWith("Y"));
