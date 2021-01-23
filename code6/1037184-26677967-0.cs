     Start:
                Console.Write("Do you want the yes or no?");
                string what = Console.ReadLine();
                switch (what)
                {
                    case "yes":
                        Console.WriteLine("You choose yes");
                        break;
                    case "no":
                        Console.WriteLine("You choose no");
                        break;
                    default:
                        Console.WriteLine("{0},is not a word", what);
                        goto Start;
                }
