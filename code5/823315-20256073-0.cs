    bool isValid = false;
    while (!isValid)
    {
        Console.WriteLine("Wrong format");
        Console.Write("       Enter mural style code >> ");
        entryString = Console.ReadLine();
        try
        {
            code = char.Parse(entryString);
            murals[x].Code = code;
            isValid = true;
        }
        catch
        {
            // Just ignore the error
            // Bad practice, which is why others are suggesting Char.TryParse
        }
    }
