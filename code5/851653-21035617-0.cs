        static void Main(string[] args)
        {
            // Instantiate the delegate.
            Del handler = DelegateMethod;
            string _a = "";
            constructor con = new constructor();
            bool control = true;
            while (control)
            {
                Console.WriteLine("Enter EXIT to end the program.");
                Console.WriteLine("Enter O for options");
                _a = Console.ReadLine();
                switch (_a.ToUpper())
                {
                    case "EXIT":
                        Console.WriteLine("Thank you for using AJ's program.");
                        control = false;
                        break;
                    case "O":
                        Console.WriteLine("Enter C for a constructor.");
                        Console.WriteLine("Enter M for a method.");
                        Console.WriteLine("Enter A for an array.");
                        Console.WriteLine("Enter D for a delegate.");
                        break;
                    case "C":
                        Console.WriteLine(con.a);
                        Console.WriteLine("Would you like to test another scenario?");
                        _a = Console.ReadLine();
                        if (_a.ToUpper() == "Y")
                        {
                            continue;
                        }
                        control = false;
                        break;
                    case "M":
                        metroid();
                        break;
                    case "A":
                        Array();
                        break;
                    case "D":
                        // call the delegate
                        handler("This is how you call a delegate. Also, Pasta noodles taste like wontons!!! =)");
                        break;
                    default:
                        Console.WriteLine("No match");
                        break;
                }
            }
        }
