    if (!System.IO.Directory.GetFiles("C:\\Users\\admin\\Desktop", "*.xls", System.IO.SearchOption.AllDirectories).Any())
    {
        Console.WriteLine("No XLS dile found");
    }
    else
    {
        Console.Write("There are xls files");
    }
