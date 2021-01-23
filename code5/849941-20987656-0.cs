    static void Main(string[] args)
    {
        string _a = "";
        constructor con = new constructor();
        bool control = true;
        while (control)
        {
            Console.WriteLine("Enter enter exit to end the program...");
            Console.WriteLine("Enter C for constructor, M for method, A for an array...");
            Console.WriteLine("Please reference source code to have full details and understanding...");
            _a = Console.ReadLine();
            switch (_a.ToUpper())
            {
                case "EXIT":
                    Console.WriteLine("Thank you for using AJ's program...");
                    control = false;
                    break;
                case "C":
                    Console.WriteLine(con.a);
                    Console.WriteLine("Would you like to test another scenario?");
                    _a = Console.ReadLine(); //<==problem #1 you didnt set your var name
                    if (_a.ToUpper() == "Y")
                    {
                        continue; //<==problem #2 return exits the program, continue, just keeps going
                    }
                    control = false;
                    break;
                case "M":
                    metroid();
                    break;
                case "A":
                    Array();
                    break;
                default:
                    Console.WriteLine("No match");
                    break;
            }
        }
    }
