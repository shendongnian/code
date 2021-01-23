    public static void Main()
    {
        DoSomethingWith("This is not a delegate demo", "display");
        DoSomethingWith("This is not a delegate demo", "write");
    }
    static void DoSomethingWith(string str, string what)
    {
        // Same runtime effect and flexibility, but...
        switch (what) {
            case "display": 
                OutputToScreen(str); break;
            case "write:
                WriteToFile(str); break;
            // what happens if "what" is neither of the above?
        }
    }
