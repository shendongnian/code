    private static string MovieListing(string name, int defaultTime = -1)
    {
        var isDefaultUsed = false;
        if (defaultTime = -1)
        {
           isDefaultUsed = true;
           defaultTime = 60;
        }
        string Name, stringTime;
        int time;
        bool isValid;
        Console.Write("What is the name of the movie?");
        Name = Console.ReadLine();
        Console.Write("What is the time of the movie? Default is 90 if left blank");
        stringTime = Console.ReadLine();
        time = Convert.ToInt32(stringTime);           
    }
