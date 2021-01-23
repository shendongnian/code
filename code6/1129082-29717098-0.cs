    public static void ShowAll(Person pers)
    {
        Console.WriteLine(pers.Name);
        foreach (var item in pers.Children)
        {
            ShowAll(item);
        }
    }
