    private static LinkedList<Prints> LList = new LinkedList<Prints>();
    
    public static void Main()
    {
        Console.Clear();
        Prints someprint = new Prints();
        someprint.ChangePrint(101.18, 101.16, 16, TimeSpan.Parse("00:00:20"), DateTime.Parse("4/8/2014 6:50:10 PM"));
        LList.AddLast(someprint);
    
        someprint = new Prints();
        someprint.ChangePrint(101.20, 101.10, 200, TimeSpan.Parse("00:00:20"), DateTime.Parse("4/8/2014 6:50:10 PM"));
        LList.AddLast(someprint);
    
        someprint = new Prints();
        someprint.ChangePrint(102.38, 102.36, 16, TimeSpan.Parse("00:00:40"), DateTime.Parse("4/8/2014 7:15:15 PM"));
        LList.AddLast(someprint);
    
        LinkedListNode<Prints> somenode = new LinkedListNode<Prints>(new Prints());
    
        somenode = LList.First;
    
        Console.WriteLine("LList");
        while (somenode != null)
        {
            somenode.Value.PrintToScreen();
            somenode = somenode.Next;
        }
        Console.ReadKey();
    }
