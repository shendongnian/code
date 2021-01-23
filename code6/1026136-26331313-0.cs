    private void FindCountries(string text)
    {
    var words = text.Split(' ');
    //List<string> myContries = new List<string>();
    var tripleRights = new List<int>();
    var doubleLefts = new List<int>();
    for (var index = 0; index < words.Length; index++)
    {
        if (String.Equals(words[index], ">>>", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine(words[index]);
            Console.WriteLine("found a triple right");
            tripleRights.Add(index);
        }
        if (String.Equals(words[index], "<<", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine(words[index]);
            Console.WriteLine("found a double left");
            doubleLefts.Add(index);
        }
    }
    Console.WriteLine("triple rights:");
    foreach (var item in tripleRights)
    {
        Console.WriteLine(item);
    }
    Console.WriteLine("double lefts");
    foreach (var item in doubleLefts)
    {
        Console.WriteLine(item);
    }
    }
