    if (line == "time") 
        Console.WriteLine("its {1}", UserName, System.DateTime.UtcNow);
    else if (line == "help") 
        Console.WriteLine("TIME: shows current time and date");
    else if (line == "easter egg") 
        Console.WriteLine("this code does funk all");
    else if (line == "easter egg") 
        Console.WriteLine("well done on finding an easter egg {0}", UserName);
    else if (line == "juggle") 
        Console.WriteLine("im sorry {0} but im not very good at party tricks", UserName);
    else
        Console.WriteLine("im sorry that is an unrecognzied commands type help for a list of commands");
