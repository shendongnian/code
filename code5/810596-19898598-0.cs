    Console.WriteLine("Please choose an option: ");
    string selectedOpt = Console.ReadLine();
    int option = 0;
    if (int.TryParse(selectedOpt, out option))
    {
        switch (option)
        {
            case 1:
            case 3:
            case 5:
            case 7:
                Console.WriteLine("Selected option {0}", option);
                break;
            default:
                Console.WriteLine("Please choose from the options list!");
                break;
        }
    }
    else
    {
        Console.WriteLine("That's an invalid option");
    }
