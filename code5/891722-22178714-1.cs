    static void Main(string[] args)
    {
        if (args.Length <= 0) //Checking the Length helps avoid NullReferenceException at args[0]
        {
            //Default behavior of your program without parameters
        }
        else
        {
            if (args[0] == "/?")
            {
                //Show Help Manual
            }
            if (args[0] == "/d")
            {
                //Do something else
            }
            //etc
        }
    }
