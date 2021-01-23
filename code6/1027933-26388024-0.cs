    try
    {
        string a = Console.ReadLine();
        if (string.IsNullOrEmpty(a))
            throw new Exception("Value must not be empty.");
        // the rest of the code
    }
    catch (Exception ex)
    {
        Console.WriteLine(e.Message);
    }
