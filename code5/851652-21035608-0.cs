            while (control)
            {
                Console.WriteLine("Enter EXIT to end the program, HELP for options");
                _a = Console.ReadLine();
                switch (_a.ToUpper())
                {
                    case "HELP":
                        Console.WriteLine("Enter C for a constructor.");
                        Console.WriteLine("Enter M for a method.");
                        Console.WriteLine("Enter A for an array.");
                        Console.WriteLine("Enter D for a delegate.");
                        break;
                    case "EXIT":
                    ....
                    ...
