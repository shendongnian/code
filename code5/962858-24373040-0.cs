    public static bool DeleteDirectory(string input)
    {
        if (Directory.Exists(input))
        {
            Directory.Delete(input, true);
            return !Directory.Exists(input);
        }
        else
            return true;
    }
    string thePath = Server.MapPath(@"~/images/");
    thePath = Path.Combine(Path.GetFullPath(thePath), txtInput.Text);
    if(DeleteDirectory(thePath))
        Console.WriteLine("YAY");
    else
        Console.WriteLine("BOO");
