    private void DoASearch(Action a)
    {
        string optionRead = string.Empty;
        do
        {
            Console.WriteLine("\nPress \"Y\" to Continue ,\"M\" For Main Menu\n");
            Console.Write("Your Choice : ");
            optionRead = Console.ReadLine().ToLower();
            if (optionRead == "y")
            {
                if(a != null)
                {
                    a();
                }
            }
            if (optionRead == "m")
            {
                m.SelectOption();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid Option.Enter M or Y\n");
                Console.ResetColor();
            }
        } while (optionRead != "m" || optionRead != "y");
    }
