    bool continue = true;
    while (continue) {
       Console.Write("Do you want the yes or no?");
       string what = Console.ReadLine();
       switch (what)
       {
            case "yes":
                Console.WriteLine("You choose yes");
                continue = false;
                break;
            case "no":
                Console.WriteLine("You choose no");
                continue = false;
                break;
            default:
                Console.WriteLine("{0}, is not a word",what);
                break;
        }
    }
