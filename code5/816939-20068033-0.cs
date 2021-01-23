    var input = "Hey; &nbsp &nbsp; Hi; ;;";
    var result = input.Split(';')
                      .Select(c => c.Replace("&nbsp", " ").Trim())
                      .Where(c => c.Length != 0);
    foreach (var item in result)
    {
        Console.WriteLine(item);
    }
