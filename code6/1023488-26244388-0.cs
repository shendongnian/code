    string value = "";
    if (openWith.TryGetValue("tif", out value))
    {
        Console.WriteLine("For key = \"tif\", value = {0}.", value);
    }
    else
    {
        Console.WriteLine("Key = \"tif\" is not found.");
    }
