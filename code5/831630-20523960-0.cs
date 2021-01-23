    [Test]
    public void PrintAllSpecialFolders()
    {
        var values = Enum.GetValues(typeof(Environment.SpecialFolder));
        Console.WriteLine("Printing special folder paths:");
        foreach (Environment.SpecialFolder value in values)
        {
            Console.WriteLine("{0}: {1}", value, Environment.GetFolderPath(value, Environment.SpecialFolderOption.None));
        }
     }
