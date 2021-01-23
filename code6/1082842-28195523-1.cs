    switch(line)
    {
        case "time": Console.WriteLine("its {1}", UserName, System.DateTime.UtcNow); break; // By the way, why pass in UserName if you aren't going to use it?
        case "help": Console.WriteLine("TIME: shows current time and date"); break;
        case "easter egg": Console.WriteLine("well done on finding an easter egg {0}", UserName); break;
        case "juggle": Console.WriteLine("im sorry {0} but im not very good at party tricks", UserName); break;
        default: Console.WriteLine("im sorry that is an unrecognzied commands type help for a list of commands");
    }
