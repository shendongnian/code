    public string GetInputstring(string myInput)
    {
        int myInt;
        Console.Write("Please enter a number: ");
        myInput = Console.ReadLine();
        myInt = Int32.Parse(myInput)
        if (myInt <= 0)
        {
            Write1(myInt);
        }
        else
        {
            Write2(myInt);
        }
        Console.ReadKey();
        return myInput;
    }
