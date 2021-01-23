    int columns = 0;
    while(true)
    {
        if (!Int32.TryParse(columnsValidation,out columns)
        {
            Console.WriteLine("You've inserted an invalid value, please try again.");
            columnsValidation = Console.ReadLine();
        }
        else
        {
            break;
        }
    }
