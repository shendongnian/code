    if (!System.IO.Directory.GetFiles("C:\\Users\\admin\\Desktop", "*.xls", System.IO.SearchOption.AllDirectories).Any())
    {
        Console.WriteLine("*.xls files not found");
    }
    else
    {
        Console.Write("*.xls files exist");
    }
