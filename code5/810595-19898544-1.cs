    bool validEntry;
    int Selection = 0;
    do
    {
    Console.WriteLine("Please choose an option: ");
            string SelectedOpt = Console.ReadLine();
            validEntry = int.TryParse(SelectedOpt , out Selection);
           if (!validEntry)
           {
              Console.WriteLine("Entry must be an integer.");
           }
            int MenuOption = (Selection);
            switch (MenuOption)
            {
                case 1:
                    Console.WriteLine("Selected option #1");
                    break;
                case 2:
                    Console.WriteLine("Selected option #3");
                    break;
                case 3:
                    Console.WriteLine("Selected option #5");
                    break;
                case 4:
                    Console.WriteLine("Selected option #7");
                    break;
                default: 
                   validEntry = false; //need to make this false again.
                    break;
            }
    
    if (!validEntry)
    {
        Console.WriteLine("Please choose from the options List!");
    }
    } while (!validEntry);
