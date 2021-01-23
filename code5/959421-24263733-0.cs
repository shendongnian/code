     Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nEnter username: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            var username = Console.ReadLine();
            if (username != null && username.Length > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Enter password: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                var password = getPassword();
                Console.WriteLine("\n");
            }
            else
            {
                Main();
            }
