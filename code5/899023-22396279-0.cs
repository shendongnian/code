    public static void Main()
    {
    int numdays;
    double total = 0.0;
    char roomtype, Continue;
    Console.WriteLine("Welcome to checkout. We hope you enjoyed your stay!");
    do
    {
        Console.Write("Please enter the number of days you stayed: ");
        numdays = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("S = Single, D = Double, L = Luxery");
        Console.Write("Please enter the type of room you stayed in: ");
        roomtype = Convert.ToChar(Console.ReadLine());
        roomtype = Char.ToUpper(roomtype);   
        total = RoomCharge(numdays,roomtype);
        Console.WriteLine("Thank you for staying at our motel. Your total is: {0}", total);
        Console.Write("Do you want to process another payment? Y/N? : ");
        Continue = Convert.ToChar(Console.ReadLine());
    } while (Continue != 'N');
    Console.WriteLine("Press any key to end");
    Console.ReadKey();
    }
