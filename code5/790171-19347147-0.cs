    do
    {
        Console.WriteLine("Enter name");
        name = Console.ReadLine();
        //Rest of your code here.
        Console.WriteLine("\nDo you want to try again?");
    }
    while(!Console.ReadLine().Equals("No"));
