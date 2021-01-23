    static int DataEntry(string rating1)
    {
        string inputValue;
        int Rating;
        Console.WriteLine("Please enter the {0}: ",rating1);
        inputValue = Console.ReadLine();
        Rating = int.Parse(inputValue); //System.FormatException was unhandled according to VS2010
    }
