    static void Main(string[] args)
    {
        int myInt = GetInputstring(); //MyInt gets set with your return value 
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
    public static int GetInputstring() //Deleted parameter because you don't need it.
    {
        string myInput;
        //int myInt;
        Console.Write("Please enter a number: ");
        myInput = Console.ReadLine();
        myInt = Int32.Parse(myInput);
        return myInt;            
    }
