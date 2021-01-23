    static void Main(string[] args)
    {
        bool control = true;
        while (control)
        {
            Console.WriteLine("Enter enter exit to end the program...");
            Console.WriteLine("Enter C for constructor, M for method, A for an array...");
            Console.WriteLine("Please reference source code to have full details and understanding...");
            string _a = Console.ReadLine();
            switch (_a.ToUpper())
            {
                case "EXIT":
                    Console.WriteLine("Thank you for using AJ's program...");
                    control = false;
                    break;
                case "C":
                    Console.WriteLine("press c");
                    Console.WriteLine("Would you like to test another scenario?");
                    Console.ReadLine();
                    if (_a.ToUpper() == "Y")
                    {
                        Console.ReadLine();
                        return;
                    }
                    control = false;
                    break;
                case "M":
                    control = false;
                    metroid();
                    break;
                case "A":
                    control = false;
                    Array();
                    break;
                default: Console.WriteLine("No match");
                    break;
            }
        }
    }
