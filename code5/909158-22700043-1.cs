    var input = Console.ReadLine(); // just for example
    if(list.Any(x => x == input))
    {
        var count = list.Count(x => x == input);
        list.Add(string.Format("{0} ({1})", input, count+1);
    } 
    else list.Add(input);
