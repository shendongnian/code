    string code1 = null;
            Console.Write("Username: " + Environment.UserName.ToString() + ">");
            string line = Console.ReadLine();
            if (line == "info")
            {
                Console.WriteLine("Info:");
            }
            else if (line == "Set Code")
            {
                if (code1 == null)
                {
                    Console.Write("TEST");
                }
                else
                {
                    Console.WriteLine("'Set Code' is not known as a command \nEnter 'info' to view all commands");
                    Console.Write("Username: " + Environment.UserName.ToString() + ">");
                }
            }
            else
            {
                Console.WriteLine("'" + line + "' is not known as a command \nEnter 'info' to view all commands");
            }
            Console.ReadLine();
