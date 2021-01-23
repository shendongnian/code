    var input = Console.ReadLine(); // just for example
    if(list.Any(x => x.Contains(input))
    {
        var count = list.Count(x => x.Contains(input));
        list.Add(string.Format("{0} ({1})", input, count+1);
    } 
    else list.Add(input);
