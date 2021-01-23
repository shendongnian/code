    static void Main(string[] args)
    {
        int myInt = GetInputstring();
        if (myInt <= 0)
        {
            Write1(myInt);
        }
        else
        {
            Write2(myInt);
        }
        Console.ReadKey();
    }
    public static int GetInputstring()
    {
        Console.Write("Please enter a number: ");
        string myInput = Console.ReadLine();
        return Int32.Parse(myInput);            
    }
